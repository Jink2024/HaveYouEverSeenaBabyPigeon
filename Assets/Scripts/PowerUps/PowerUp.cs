using UnityEngine;

using System.Collections;

public abstract class PowerUp : MonoBehaviour
{
    protected virtual float Duration => GameParameters.LaserPowerUpDuration;

    public abstract IEnumerator Apply(GameObject player);
}