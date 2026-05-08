using System.Collections;
using UnityEngine;

public class LaserPowerUp : PowerUp
{
    [SerializeField] private GameObject laserGunPrefab;
    protected override float Duration => GameParameters.LaserPowerUpDuration;
    public override IEnumerator Apply(GameObject player)
    {
        Launcher launcher = player.GetComponent<Launcher>();

        if (launcher == null)
            yield break;

        launcher.EquipWeapon(laserGunPrefab);

        yield return new WaitForSeconds(Duration);

        launcher.EquipDefaultWeapon();
    }
}

