using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip cubeVisitedClip; 
  [SerializeField]  private AudioSource audioSource;

    void Start()
    {
     
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayCubeVisitedSound()
    {
        if (cubeVisitedClip != null)
        {
            audioSource.PlayOneShot(cubeVisitedClip);
        }
    }
}
