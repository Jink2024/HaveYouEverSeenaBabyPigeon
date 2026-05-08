using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private GameObject defaultWeaponPrefab;
    
    public Weapon CurrentWeapon;
    private float _lastFireTime = -Mathf.Infinity;

    private void Awake()
    {
        EquipWeapon(defaultWeaponPrefab);
    }
    
    public void EquipDefaultWeapon()
    {
        EquipWeapon(defaultWeaponPrefab);
    }

    public void Launch(Vector2 aimDirection)
    {
        if (CurrentWeapon == null || !CanFire())
            return;
        
        _lastFireTime = Time.time;
        
        CurrentWeapon.Shoot(aimDirection);
    }
    
    private bool CanFire()
    {
        return Time.time >= _lastFireTime + CurrentWeapon.FireCooldown;
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