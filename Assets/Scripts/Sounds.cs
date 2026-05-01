using UnityEngine;

public class Sounds : MonoBehaviour
{
   public AudioClip GunClip;
   
   private AudioSource audioSource;

   public void Awake()
   {
      audioSource = GetComponent<AudioSource>();
   }
   
   public void PlayGunSound()
   {
      audioSource.PlayOneShot(GunClip);
   }

}
