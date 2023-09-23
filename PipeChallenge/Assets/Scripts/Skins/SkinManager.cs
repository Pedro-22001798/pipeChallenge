using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Transform skinsPrefabs;
    public static SkinManager Instance {get; private set;}
    [SerializeField] private View view;
    public SkinType SkinType {get; private set;}

    private void Awake() 
    { 
        ChangeSkin(SkinType.normal);
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 

        foreach(Transform t in skinsPrefabs)
        {
            SkinPrefab sp = t.GetComponent<SkinPrefab>();
            if(sp.GetSkin() == SkinType)
            {
                ChangeSkin(sp.GetSkin(),t);
            }
        }
    }

    public void ChangeSkin(SkinType newSkinType)
    {
        SkinType = newSkinType;
        view.ChangeSkin(SkinType);        
    }

    public void ChangeSkin(SkinType newSkinType, Transform activeButton)
    {
        SkinType = newSkinType;
        view.ChangeSkin(SkinType);
        view.ActiveSkinButton(activeButton);
    }
}
