using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioLibrary BgmLibrary;
    [SerializeField] private AudioLibrary SfxLibrary;

    void Awake()
    {
        // Cria os AudioSource dinamicamente se nao tiver
        if (bgmSource == null) bgmSource = gameObject.AddComponent<AudioSource>();
        if (sfxSource == null) sfxSource = gameObject.AddComponent<AudioSource>();
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
    public void PlaySFX(string key)
    {
        var clip = SfxLibrary.GetClip(key);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SFX '{key}' nao encontrado!");
        }
    }
}
