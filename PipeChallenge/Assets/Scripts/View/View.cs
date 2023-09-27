using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class View : MonoBehaviour
{
    [SerializeField] private Transform pipeContainer, skinsContainer, levelContainer;
    [SerializeField] private GameObject[] pipePrefabs;
    [SerializeField] private TextMeshProUGUI currentLevelText, playerScoreText, timerText, stageText;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Material[] pipeMaterials;
    [SerializeField] private ConnectionsController connectionsController;
    [SerializeField] private LevelController levelController;
    [SerializeField] private AllLevels allLevels;
    [SerializeField] private Animator levelTransitor, endTextAnimator, endBackgroundAnimator, chooseLevelMenu, timerTextAnimator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Skin[] allSkins;
    [SerializeField] private Animator[] optionsAnimators;
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private GameObject[] stars;
    private ILevel currentLevel;
    bool isLerping = false;
    private List<Animator> allPipeAnimators;
    private int gridSizeX, gridSizeY;

    [System.Serializable]
    public class Skin
    {
        public Sprite[] skins;
    }

    public void BuildLevel(ILevel level)
    {
        currentLevel = level;
        currentLevelText.text = $"{level.LevelNumber}#";
        RebuildMap(true);
    }

    private void InitiateLevel(ILevel level)
    {
        levelController.LoadNewLevel(level);
        connectionsController.DefinePipes();
        timerTextAnimator.SetTrigger("Show");
    }

    public void LightPipe(SpriteRenderer sr)
    {
        if(sr != null)
        {
            sr.material = pipeMaterials[1];
        }
    }

    public void UnlightPipe(SpriteRenderer sr)
    {
        if(sr != null)
        {
            sr.material = pipeMaterials[0];
        }
    }

    public void RotatePipe(Transform pipeTransform, PipeClick pipe)
    {
        StartCoroutine(RotatePipeCoroutine(pipeTransform,pipe));
        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.rotate);
    }

    public void BlockRotation(Transform pipeTransform, PipeClick pipe)
    {
        StartCoroutine(BlockRotationAnimation(pipeTransform,pipe));
        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
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
        connectionsController.CheckConnections();
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
            case PipeType.mix:
                return pipePrefabs[2];
            case PipeType.light:
                return pipePrefabs[3];
            case PipeType.end:
                return pipePrefabs[4];
        }

        return pipePrefabs[5];
    }

    public void PauseGame()
    {
        if(!isLerping)
        {
            {
                if(GameStateMachine.Instance.CurrentGameState == GameState.playing)
                {
                    float currentSize = cameraController.CalculateCameraSize(gridSizeX,gridSizeY);
                    float newSize = currentSize + 2f;
                    StartCoroutine(LerpCameraSize(newSize,0.5f));
                }
            }
        }
    }

    public void ResumeGame()
    {
        if(!isLerping)
        {
            if(GameStateMachine.Instance.CurrentGameState == GameState.paused)
            {
                float currentSize = mainCamera.orthographicSize;
                float newSize = cameraController.CalculateCameraSize(gridSizeX,gridSizeY);
                StartCoroutine(LerpCameraSize(newSize,0.5f)); 
            } 
        }    
    }

    public void LevelTransition()
    {
        timerTextAnimator.SetTrigger("Hide");
        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.transition);
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

    public void WinLevel(int tempScore)
    {
        List<SpriteRenderer> sr = new List<SpriteRenderer>();
        foreach(Transform t in pipeContainer)
        {
            PipeClick pc = t.GetComponent<PipeClick>();
            if(pc != null)
            {
                if(pc.Pipe.TypeOfPipe == PipeType.end)
                {
                    SpriteRenderer sr2 = t.GetComponent<SpriteRenderer>();
                    sr.Add(sr2);
                }
            }
        }

        for(int i = 0; i < tempScore; i++)
        {
            stars[i].SetActive(true);
        }

        endBackgroundAnimator.SetTrigger("WinLevel");
        endTextAnimator.SetTrigger("WinLevel");
        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.win);
        StartCoroutine(LerpEndPipesMaterials(sr,0.5f));
        StartCoroutine(WaitToHideStars());
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

    private IEnumerator WaitToHideStars()
    {
        yield return new WaitForSeconds(3.5f);
        foreach(GameObject star in stars)
            star.SetActive(false);        
    }

    public void ChangeSkin(SkinType skinType)
    {    
        for (int i = 0; i < pipePrefabs.Length-1; i++)
        {
            SpriteRenderer sr = pipePrefabs[i].GetComponent<SpriteRenderer>();

            switch (skinType)
            {
                case SkinType.triangular:
                    sr.sprite = allSkins[1].skins[i];
                    break;
                default:
                    sr.sprite = allSkins[0].skins[i];
                    break;
            }
        }      
    }

    public void ActiveSkinButton(Transform activeButton, Transform container)
    {
        foreach(Transform t in container)
        {
            Image outline = t.GetChild(0).GetComponent<Image>();
            if(t == activeButton)
            {
                outline.color = Color.white;
            }
            else
            {
                outline.color = Color.black;
            }
        }
    }

    public void RebuildMap(bool isRestart)
    {
        gridSizeX = 0;
        gridSizeY = 0;
        allPipeAnimators = new List<Animator>();
        ClearLevel();
        List<IPipe> allPipes = currentLevel.GetAllPipes();
        foreach (IPipe p in allPipes)
        {
            gridSizeX = Mathf.Max(gridSizeX, p.Row);
            gridSizeY = Mathf.Max(gridSizeY, p.Col);  
            Quaternion rotation;  
            if(isRestart)
            {
                rotation = Quaternion.Euler(0, 0, p.StartRotation);
                p.Restart();
            }  
            else
            {
                rotation = Quaternion.Euler(0, 0, p.CurrentRotation);
            }    
            GameObject pipe = Instantiate(GetPipePrefab(p.TypeOfPipe), new Vector3(p.Col, -p.Row, 0), rotation, pipeContainer);
            Animator animator = pipe.GetComponent<Animator>();
            if(animator != null)
                allPipeAnimators.Add(animator);
            PipeClick pipeClick = pipe.GetComponent<PipeClick>();
            if(pipeClick != null)
                pipeClick.DefinePipe(p, this);
        }
        if(isRestart)
        {
            cameraController.CalculateCameraPosition(gridSizeX, gridSizeY);
            foreach(Transform pipe in pipeContainer)
            {
                PipeClick pipeClick = pipe.GetComponent<PipeClick>();
                if(pipeClick != null)
                {
                    if(pipeClick.Pipe.TypeOfPipe != PipeType.light)
                    {
                        SpriteRenderer sr = pipe.GetComponent<SpriteRenderer>();
                        UnlightPipe(sr);
                    }
                }
            }
        }
        AnimateMap(true);
        InitiateLevel(currentLevel);
    }

    public void AnimateMap(bool show)
    {
        List<Animator> remainingAnimators = new List<Animator>();
        List<Animator> previousAnimator = new List<Animator>();
        remainingAnimators = allPipeAnimators;
        if(show)
        {
            ShuffleList(remainingAnimators);
            foreach (var animator in remainingAnimators)
            {
                StartCoroutine(DelayAnimation(animator,0.3f,"Show"));
                previousAnimator.Add(animator);
            }
        }
        else
        {
            ShuffleList(remainingAnimators);
            foreach (var animator in remainingAnimators)
            {
                StartCoroutine(DelayAnimation(animator,0.3f,"Hide"));
                previousAnimator.Add(animator);
            }          
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private IEnumerator DelayAnimation(Animator animator, float duration, string command)
    {
        yield return new WaitForSeconds(duration);
        animator.SetTrigger(command);
    }

    public void OpenCloseOptions(bool isOpening)
    {
        if(isOpening)
        {
            if(GameStateMachine.Instance.CurrentGameState == GameState.playing)
            {
                for(int i = 0; i < optionsAnimators.Length; i++)
                {
                    string mode;
                    if(i == 0)
                        mode = "Pressed";
                    else
                        mode = "Show";
                    optionsAnimators[i].SetTrigger(mode);
                }
            }
        }
        else
        {
            if(GameStateMachine.Instance.CurrentGameState == GameState.paused)
            {
                for(int i = 0; i < optionsAnimators.Length; i++)
                {
                    string mode;
                    if(i == 0)
                        mode = "Show";
                    else if(i > 0 && i < optionsAnimators.Length-1)
                        mode = "Hide";
                    else
                        mode = "Pressed";
                    optionsAnimators[i].SetTrigger(mode);
                }
            }
        }
    }

    public void CreateLevelsUI(List<ILevel> allLevels)
    {
        ResetLevelsUI();
        foreach(ILevel level in allLevels)
        {
            GameObject tempLevel = Instantiate(levelPrefab,levelContainer);
            LevelPrefab lp = tempLevel.GetComponent<LevelPrefab>();
            lp.DefineLevel(level,this);
        }
    }

    private void ResetLevelsUI()
    {
        foreach(Transform t in levelContainer)
        {
            Destroy(t.gameObject);
        }
    }

    public void HideShowLevelMenu(bool isShow)
    {
        if(!isShow)
        {
            foreach(Transform t in levelContainer)
            {
                Animator anim = t.GetComponent<Animator>();
                anim.SetTrigger("Hide");
            }
            chooseLevelMenu.SetTrigger("Hide");
            optionsAnimators[0].gameObject.SetActive(true);
            optionsAnimators[0].SetTrigger("Show");
            GameStateMachine.Instance.ResumeGame();
        }
        else
        {
            optionsAnimators[0].gameObject.SetActive(false);
            OpenCloseOptions(!isShow);
            chooseLevelMenu.SetTrigger("Show");
            timerTextAnimator.SetTrigger("Hide");
            CreateLevelsUI(allLevels.GetAllLevels());
        }
    }

    public void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        string timerString = string.Empty;
        if(minutes > 0)
            timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        else
            timerString = string.Format("{0:00}",seconds);

        timerText.text = timerString;
    }

    public void UpdateStageText(int stage)
    {
        stageText.text = $"Stage #{stage}";
    }
}
