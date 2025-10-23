using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource randomPitchAudioSource;
    [SerializeField] private AudioLibrary BgmLibrary;
    [SerializeField] private AudioLibrary SfxLibrary;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    // ----------- BGM -----------
    public void PlayBGM(string key)
    {
        var clip = BgmLibrary.GetClip(key);
        if (clip != null)
        {
            bgmSource.clip = clip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning($"BGM '{key}' nao encontrado!");
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // ----------- SFX -----------
    public void PlaySFX(string key, bool randomPitch = false)
    {
        var clip = SfxLibrary.GetClip(key);

        if (clip != null)
        {
            if (randomPitch)
            {
                randomPitchAudioSource.pitch = Random.Range(0.8f, 1.2f);
                randomPitchAudioSource.PlayOneShot(clip);
            }
            else
            {
                sfxSource.PlayOneShot(clip);
            }
        }
        else
        {
            Debug.LogWarning($"SFX '{key}' nao encontrado!");
        }
    }
}
