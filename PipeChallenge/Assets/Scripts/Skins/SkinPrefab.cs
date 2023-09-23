using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPrefab : MonoBehaviour
{
    [SerializeField] private SkinType skinType;
    private bool isUnlocked = false;

    public void UnlockSkin()
    {
        if(!isUnlocked)
        {
            isUnlocked = true;
        }
        ChooseSkin();
    }

    public void ChooseSkin()
    {
        SkinManager.Instance.ChangeSkin(skinType,this.transform);
        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.interfaceclick);
    }

    public SkinType GetSkin()
    {
        return skinType;
    }
}
