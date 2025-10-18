using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _sfxSource;
    private AudioSource _audioSource;

    public AudioClip menuBGM;
    public AudioClip gameOver;

    public AudioClip _starSFX;
    public AudioClip _coinsSFX;
    public float delay = 2;


    void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public void ReproduceSound(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip bgmClip)
    {
        _bgmSource.clip = bgmClip;
        _bgmSource.Play();
    }

    /*public void Victory()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(victory);
    }*/

    public void StopMusic()
    {
        _audioSource.Stop();
    }

}
