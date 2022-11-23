using System.Collections;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;

        float timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPosition.z);

            timeElapsed  = timeElapsed + 0.003f;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
