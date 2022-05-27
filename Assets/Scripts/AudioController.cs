using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip jumpSFX;
    public AudioClip appleSFX;

    private AudioSource audioSource;
    

    public static AudioController instance;

    private void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx)
    {
        if (sfx.name == "apple")
        {
            audioSource.pitch = 3;
        }
        else
        {
            audioSource.pitch = 1;
        }

        audioSource.PlayOneShot(sfx);
    }
}
