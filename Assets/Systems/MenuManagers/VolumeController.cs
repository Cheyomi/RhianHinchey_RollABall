using UnityEngine;
using UnityEngine.UI; 

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;    
    public AudioSource musicAudioSource;   

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);

        volumeSlider.value = savedVolume;
        musicAudioSource.volume = savedVolume;


        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        musicAudioSource.volume = value;
        PlayerPrefs.SetFloat("Volume", value);

    }
}