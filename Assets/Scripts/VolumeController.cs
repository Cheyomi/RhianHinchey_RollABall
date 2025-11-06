using UnityEngine;
using UnityEngine.UI; 

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;    
    public AudioSource musicSource;   
    public float startingVolume = 0.4f; 

    void Start()
    {
        volumeSlider.value = startingVolume;
        AudioListener.volume = startingVolume;

        if (musicSource != null)
            musicSource.volume = startingVolume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;

        if (musicSource != null)
            musicSource.volume = value;
    }
}