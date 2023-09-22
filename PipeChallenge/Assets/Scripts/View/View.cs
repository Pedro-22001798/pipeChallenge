using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : MonoBehaviour, IView
{
    [SerializeField] private Transform pipeContainer;
    [SerializeField] private GameObject[] pipePrefabs;
    [SerializeField] private TextMeshProUGUI currentLevelText, playerScoreText;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Material[] pipeMaterials;
    [SerializeField] private ConnectionsController connectionsController;
    [SerializeField] private LevelController levelController;
    [SerializeField] private Animator levelTransitor, endTextAnimator, endBackgroundAnimator;
    [SerializeField] private Camera mainCamera;
    bool isLerping = false;

    public void BuildLevel(ILevel level)
    {
        currentLevelText.text = $"{level.LevelNumber}#";
        List<IPipe> allPipes = level.GetAllPipes();
        ClearLevel();
        int gridSizeX = 0, gridSizeY = 0;
        foreach (IPipe p in allPipes)
        {
            gridSizeX = Mathf.Max(gridSizeX, p.Row);
            gridSizeY = Mathf.Max(gridSizeY, p.Col);
            Quaternion rotation = Quaternion.Euler(0, 0, p.Rotation);
            GameObject pipe = Instantiate(GetPipePrefab(p.TypeOfPipe), new Vector3(p.Col, -p.Row, 0), rotation, pipeContainer);
            PipeClick pipeClick = pipe.GetComponent<PipeClick>();
            pipeClick.DefinePipe(p, this);
        }
        levelController.LoadNewLevel(level);
        cameraController.CalculateCameraPosition(gridSizeX, gridSizeY);
        connectionsController.DefinePipes();
        connectionsController.CheckConnections();
        GameStateMachine.Instance.ResumeGame();
    }


    public void LightPipe(SpriteRenderer sr)
    {
        sr.material = pipeMaterials[1];
    }

    public void UnlightPipe(SpriteRenderer sr)
    {
        sr.material = pipeMaterials[0];
    }

    public void RotatePipe(Transform pipeTransform, PipeClick pipe)
    {
        StartCoroutine(RotatePipeCoroutine(pipeTransform,pipe));
    }

    public void BlockRotation(Transform pipeTransform, PipeClick pipe)
    {
        StartCoroutine(BlockRotationAnimation(pipeTransform,pipe));
    }

    private IEnumerator RotatePipeCoroutine(Transform pipeTransform, PipeClick pipe)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = pipeTransform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 0f, 90f); // Rotate by 90 degrees

        while (elapsedTime < 0.5f)
        {
            pipeTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation is exact at the end
        pipeTransform.rotation = targetRotation;
        pipe.AllowRotation();
    }

    private IEnumerator BlockRotationAnimation(Transform pipeTransform, PipeClick pipe)
    {
        Quaternion originalRotation = pipeTransform.rotation;
        Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, 15f);

        float rotationDuration = 0.1f;
        float returnDuration = 0.05f;
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            pipeTransform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation ends exactly at the target rotation
        pipeTransform.rotation = targetRotation;

        // Wait for a short duration
        yield return new WaitForSeconds(returnDuration);

        // Return to the original rotation
        elapsedTime = 0f;
        while (elapsedTime < returnDuration)
        {
            pipeTransform.rotation = Quaternion.Slerp(targetRotation, originalRotation, elapsedTime / returnDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation ends exactly at the original rotation
        pipeTransform.rotation = originalRotation;
        pipe.AllowRotation();
    }

    public void ClearLevel()
    {
        foreach(Transform t in pipeContainer)
        {
            Destroy(t.gameObject);
        }
    }

    private GameObject GetPipePrefab(PipeType typeOfPipe)
    {
        switch(typeOfPipe)
        {
            case PipeType.normal:
                return pipePrefabs[0];
            case PipeType.curve:
                return pipePrefabs[1];
            case PipeType.light:
                return pipePrefabs[2];
            case PipeType.end:
                return pipePrefabs[3];
        }

        return pipePrefabs[0];
    }

    public void PauseGame()
    {
        if(!isLerping)
        {
            float currentSize = mainCamera.orthographicSize;
            float newSize = currentSize + 2f;
            StartCoroutine(LerpCameraSize(newSize,0.5f));
        }
    }

    public void ResumeGame()
    {
        if(!isLerping)
        {
            float currentSize = mainCamera.orthographicSize;
            float newSize = currentSize - 2f;
            StartCoroutine(LerpCameraSize(newSize,0.5f));  
        }    
    }

    public void LevelTransition()
    {
        levelTransitor.SetTrigger("PassLevel");
    }

    public void UpdateScoreText(int score)
    {
        playerScoreText.text = $"Score = {score}";
    }

    private IEnumerator LerpCameraSize(float targetSize, float lerpDuration)
    {
        isLerping = true;
        float elapsedTime = 0f;
        float startSize = mainCamera.orthographicSize;

        while (elapsedTime < lerpDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.orthographicSize = targetSize;
        isLerping = false;
    }

    public void WinLevel()
    {
        List<SpriteRenderer> sr = new List<SpriteRenderer>();
        foreach(Transform t in pipeContainer)
        {
            PipeClick pc = t.GetComponent<PipeClick>();
            if(pc.Pipe.TypeOfPipe == PipeType.end)
            {
                SpriteRenderer sr2 = t.GetComponent<SpriteRenderer>();
                sr.Add(sr2);
            }
        }
        endBackgroundAnimator.SetTrigger("WinLevel");
        endTextAnimator.SetTrigger("WinLevel");
        StartCoroutine(LerpEndPipesMaterials(sr,0.5f));
    }

    private IEnumerator LerpEndPipesMaterials(List<SpriteRenderer> allEndPipes, float lerpDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < lerpDuration)
        {
            float t = elapsedTime / lerpDuration;
            foreach(SpriteRenderer sr in allEndPipes)
            {
                sr.material.Lerp(pipeMaterials[1], pipeMaterials[2], t);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        foreach(SpriteRenderer sr in allEndPipes)
        {
            sr.material = pipeMaterials[2];
        }
    }
}
