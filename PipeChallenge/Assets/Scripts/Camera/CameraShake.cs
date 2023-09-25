using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Shake duration
    private float duration = 0.35f;
    // Shake magnitude
    private float magnitude = 0.0035f;

    /// <summary>
    /// Method called when camera is going to shake
    /// </summary>
    public void ShakeCamera()
    {
        StartCoroutine(Shake(duration,magnitude));
    }

    /// <summary>
    /// Coroutine to shake the camera
    /// </summary>
    /// <param name="duration">Shake duration</param>
    /// <param name="magnitude">Shake magnitude</param>
    /// <returns></returns>
    private IEnumerator Shake(float duration, float magnitude)
    {
        // Gets the original camera position
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            // Gets random camera position
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            // Moves camera to random position
            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        // Moves camera to original position
        transform.position = orignalPosition;
    }
}