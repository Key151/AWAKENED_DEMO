using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;

    AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        audioManager.SetVolumeSFX(sfxSlider.value);
        audioManager.SetVolumeBGM(bgmSlider.value);

        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanceSFX(); });
        bgmSlider.onValueChanged.AddListener(delegate { OnValueChanceBGM(); });
    }

    // ----------- BGM -----------

    public void OnValueChanceBGM()
    {
        audioManager.SetVolumeBGM(bgmSlider.value);
    }

    // ----------- SFX -----------

    public void OnValueChanceSFX()
    {
        audioManager.SetVolumeSFX(sfxSlider.value);
    }
}
