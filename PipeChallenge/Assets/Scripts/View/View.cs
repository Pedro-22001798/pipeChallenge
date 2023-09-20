using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour, IView
{
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

}
