using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private float duration = 0.35f;
    private float magnitude = 0.0035f;

    public void ShakeCamera()
    {
        StartCoroutine(Shake(duration,magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}