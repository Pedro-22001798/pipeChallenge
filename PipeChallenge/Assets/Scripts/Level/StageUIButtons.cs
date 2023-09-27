using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUIButtons : MonoBehaviour
{
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private StageController stageController;
    [SerializeField] private View view;

    void Start()
    {
        view.UpdateStageText(stageController.CurrentStage);
    }

    public void PreviousStage()
    {
        if(stageController.IsThereStage(stageController.CurrentStage-1))
        {
            List<ILevel> allStageLevels = stageController.GetAllStageLevels(stageController.CurrentStage-1);
            stageController.ChangeStage(stageController.CurrentStage-1);
            view.CreateLevelsUI(allStageLevels);
            view.UpdateStageText(stageController.CurrentStage);
        }
        else
        {
            cameraShake.ShakeCamera();
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
        }
    }

    public void NextStage()
    {
        if(stageController.IsThereStage(stageController.CurrentStage+1))
        {
            List<ILevel> allStageLevels = stageController.GetAllStageLevels(stageController.CurrentStage+1);
            stageController.ChangeStage(stageController.CurrentStage+1);
            view.CreateLevelsUI(allStageLevels);
            view.UpdateStageText(stageController.CurrentStage);
        }
        else
        {
            cameraShake.ShakeCamera();
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
        }
    }
}
