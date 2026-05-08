using UnityEngine;

using System.Collections;

public abstract class PowerUp : MonoBehaviour
{
    public float Duration = 10f;

    public abstract IEnumerator Apply(GameObject player);
}