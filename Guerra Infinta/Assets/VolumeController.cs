using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxSlider.value = sfxSlider.maxValue;
        bgmSlider.value = bgmSlider.maxValue;

        if(AudioManager.Instance.GetVolumeBGM() != 1.0f || AudioManager.Instance.GetVolumeSFX() != 1.0f)
        {
            sfxSlider.value = AudioManager.Instance.GetVolumeSFX();
            bgmSlider.value = AudioManager.Instance.GetVolumeBGM();
        }
        else
        {
            AudioManager.Instance.SetVolumeSFX(sfxSlider.value);
            AudioManager.Instance.SetVolumeBGM(bgmSlider.value);
        }

        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanceSFX(); });
        bgmSlider.onValueChanged.AddListener(delegate { OnValueChanceBGM(); });    
    }

    // ----------- SFX -----------

    public void OnValueChanceSFX()
    {
        AudioManager.Instance.SetVolumeSFX(sfxSlider.value);
    }

    // ----------- BGM -----------

    public void OnValueChanceBGM()
    {
        AudioManager.Instance.SetVolumeBGM(bgmSlider.value);
    }
}
