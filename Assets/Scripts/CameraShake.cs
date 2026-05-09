using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Shake(
        float duration,
        float strength = 1f,
        int vibrato = 10)
    {
        transform.DOShakePosition(
            duration,
            strength,
            vibrato
        );
    }
}