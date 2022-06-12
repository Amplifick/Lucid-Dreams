using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreenCode : MonoBehaviour
{
    //Only FullScreen (FS).
    public Toggle toggle;

    //Only Resolutions (Res).
    public TMP_Dropdown resolutionsDropDown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        //Only Fs.
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        //Only Res.
        CheckResolutions();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Only Fs.
    public void enableFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    //Only Res.
    public void CheckResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;


        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = currentResolution;
        resolutionsDropDown.RefreshShownValue();

        resolutionsDropDown.value = PlayerPrefs.GetInt("resolutionNumber", 0);

    }

    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("resolutionNumber", resolutionsDropDown.value);

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
