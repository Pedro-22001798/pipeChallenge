using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : MonoBehaviour, IView
{
    [SerializeField] private Transform pipeContainer;
    [SerializeField] private GameObject[] pipePrefabs;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Material[] pipeMaterials;
    [SerializeField] private ConnectionsController connectionsController;

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
        cameraController.CalculateCameraPosition(gridSizeX, gridSizeY);
        connectionsController.CheckConnections();
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
}
