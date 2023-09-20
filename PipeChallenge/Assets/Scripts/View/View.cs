using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour, IView
{
    [SerializeField] private Transform pipeContainer;
    [SerializeField] private GameObject[] pipePrefabs;

    public void BuildLevel(ILevel level)
    {
        List<IPipe> allPipes = level.GetAllPipes();
        ClearLevel();
        foreach(IPipe p in allPipes)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, p.Rotation);
            GameObject pipe = Instantiate(GetPipePrefab(p.TypeOfPipe),new Vector3(p.Col,-p.Row,0),rotation,pipeContainer);
        }
    }

    public void LightPipe()
    {

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
            Destroy(t);
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
