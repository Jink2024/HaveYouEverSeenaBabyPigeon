using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawnPoint;
    
    public void Launch(Vector2 aimDirection)
    {
        // create a ball at the gun
        GameObject projectileObject = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, 
            Quaternion.identity);
        
        // start the ball moving forward
        MoveProjectile(projectileObject, aimDirection);
    }

    private void MoveProjectile(GameObject projectileObject, Vector2 aimDirection)
    {
        Rigidbody2D projectileRigidbody = projectileObject.GetComponent<Rigidbody2D>();
        
        // add force to the object in the direction
        projectileRigidbody.AddForce(aimDirection * 10f, ForceMode2D.Impulse); // Add in GameParameters later
        
    }
}
