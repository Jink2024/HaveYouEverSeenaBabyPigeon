using UnityEngine;

public class BirdLoot : MonoBehaviour
{
    [SerializeField] private GameObject lootPrefab;

    [SerializeField] [Range(0f, 1f)] private float dropChance = GameParameters.BoxDropChance;

    public void DropLoot()
    {
        if (Random.value > dropChance)
            return;

        Instantiate(lootPrefab, transform.position, Quaternion.identity);
    }
}