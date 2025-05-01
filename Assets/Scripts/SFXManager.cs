using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip hit, score;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
