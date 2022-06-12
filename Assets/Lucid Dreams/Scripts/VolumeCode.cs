using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeCode : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image muteStateImage;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckMuteState();
    }

    public void ChangeSlider(float val)
    {
        sliderValue = val;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckMuteState();
    }

    public void CheckMuteState()
    {
        if (sliderValue == 0)
        {
            muteStateImage.enabled = true;
        }
        else
        {
            muteStateImage.enabled = false;
        }
    }
}
