using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessCode : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image brightnessPanelOptions;
    public Image brightnessPanelMain;
    public Image brightnessPanelPopUp;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brightness", 0.5f);

        brightnessPanelOptions.color = new Color(brightnessPanelOptions.color.r, brightnessPanelOptions.color.g, brightnessPanelOptions.color.b, slider.value);
        brightnessPanelMain.color = new Color(brightnessPanelMain.color.r, brightnessPanelMain.color.g, brightnessPanelMain.color.b, slider.value);
        brightnessPanelPopUp.color = new Color(brightnessPanelPopUp.color.r, brightnessPanelPopUp.color.g, brightnessPanelPopUp.color.b, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float val)
    {
        sliderValue = val;
        PlayerPrefs.SetFloat("brightness", sliderValue);
        brightnessPanelOptions.color = new Color(brightnessPanelOptions.color.r, brightnessPanelOptions.color.g, brightnessPanelOptions.color.b, slider.value);
        brightnessPanelMain.color = new Color(brightnessPanelMain.color.r, brightnessPanelMain.color.g, brightnessPanelMain.color.b, slider.value);
        brightnessPanelPopUp.color = new Color(brightnessPanelPopUp.color.r, brightnessPanelPopUp.color.g, brightnessPanelPopUp.color.b, slider.value);
    }

}
