using UnityEngine;

public class Sounds : MonoBehaviour
{
   private AudioSource audioSource;

   [SerializeField] private AudioClip bulletSound;
   [SerializeField] private AudioClip laserSound;
   [SerializeField] private AudioClip nukeSound;
   
   private void Awake()
   {
      audioSource = GetComponent<AudioSource>();
   }
   
   public void PlayBulletSound()
   {
      audioSource.PlayOneShot(bulletSound);
   }

   public void PlayLaserSound()
   {
      audioSource.PlayOneShot(laserSound);
   }

   public void PlayNukeSound()
   {
      audioSource.PlayOneShot(nukeSound);
   }

}
