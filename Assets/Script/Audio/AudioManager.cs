using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource sfxSource;
    public AudioClip backgroundMusicClip;
    public AudioClip explotionClip;
    public AudioClip woodBreakClip;
    public AudioClip wallBreakClip;
    public AudioClip throwClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
