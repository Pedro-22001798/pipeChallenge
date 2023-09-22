using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private View view;
    public SkinType SkinType {get; private set;}

    void Start()
    {
        ChangeSkin(SkinType.normal);
    }

    public void ChangeSkin(SkinType newSkinType)
    {
        SkinType = newSkinType;
        view.ChangeSkin(SkinType);
    }
}
