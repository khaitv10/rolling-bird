
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
   [SerializeField] AudioSource SFXSource;
   [SerializeField] AudioSource musicSource;


    [Header("-----Audio Clip-----")]
    
    public AudioClip music;
   public AudioClip point;
   public AudioClip death;
   public AudioClip roll;

   private void Start()
   {
        musicSource.clip = music;
        musicSource.Play();
   }

   public void PlayFSX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
   }

}
