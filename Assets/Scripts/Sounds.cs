using UnityEngine;

public class Sounds : MonoBehaviour
{
   [SerializeField] private AudioSource sfxAudioSource;
   [SerializeField] private AudioSource loopAudioSource;

   [SerializeField] private AudioClip bulletSound;
   [SerializeField] private AudioClip laserSound;
   [SerializeField] private AudioClip nukeSound;
   [SerializeField] private AudioClip slowdownSound;
   
   
   public void PlayBulletSound()
   {
      sfxAudioSource.PlayOneShot(bulletSound);
   }

   public void PlayLaserSound()
   {
      sfxAudioSource.PlayOneShot(laserSound);
   }

   public void PlayNukeSound()
   {
      sfxAudioSource.PlayOneShot(nukeSound);
   }

   public void PlaySlowdownSound()
   {
      loopAudioSource.Stop();
      loopAudioSource.clip = slowdownSound;
      loopAudioSource.Play();
   }
   public void StopSlowdownSound()
   {
      if (loopAudioSource.clip == slowdownSound)
      {
         loopAudioSource.Stop();
      }
   }

}
