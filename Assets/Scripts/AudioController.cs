using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; 
    public AudioSource audioSource;  

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);  
        audioSource.volume = savedVolume;  
        volumeSlider.value = savedVolume;  
    }

    public void OnVolumeChanged()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
}
}