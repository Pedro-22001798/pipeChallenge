using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Shake(5f,5f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        yield return new WaitForSeconds(3f);
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}