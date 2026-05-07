using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject bulletGunPrefab;
    [SerializeField] private Transform weaponHolder;
    
    public Weapon CurrentWeapon;
    
    private void Awake()
    {
        EquipWeapon(bulletGunPrefab);
    }

    public void Launch(Vector2 aimDirection)
    {
        if (CurrentWeapon == null)
            return;

        CurrentWeapon.Shoot(aimDirection);
    }
    
    public void EquipWeapon(GameObject weaponPrefab)
    {
        foreach (Transform child in weaponHolder)
        {
            Destroy(child.gameObject);
        }

        GameObject weaponObject =
            Instantiate(
                weaponPrefab,
                weaponHolder
            );

        CurrentWeapon =
            weaponObject.GetComponent<Weapon>();
    }
}