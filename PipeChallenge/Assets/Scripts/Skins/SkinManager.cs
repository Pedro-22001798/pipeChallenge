using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Transform skinsPrefabs;
    public static SkinManager Instance {get; private set;}
    [SerializeField] private View view;
    public SkinType SkinType {get; private set;}
    private bool isActive = true;

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
        view.ActiveSkinButton(activeButton,skinsPrefabs);
    }

    public void ActivateDeactivateSkinsContainer()
    {
        isActive = !isActive;
        if(!isActive)
        {
            foreach(Transform t in skinsPrefabs)
            {
                Animator anim = t.GetComponent<Animator>();
                anim.SetTrigger("Hide");
            }
            StartCoroutine(WaitToDeactivate());
        }
        else
        {
            skinsPrefabs.gameObject.SetActive(isActive);
        }
    }

    private IEnumerator WaitToDeactivate()
    {
        yield return new WaitForSeconds(0.3f);
        skinsPrefabs.gameObject.SetActive(false);
    }
}
