using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Animations;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Animator backButtonAnimator;
    public Animator animator;

    [SerializeField] bool isHovering;


    Resolution nativeResolution;

    public int exceptionResolutionIndex = 22;

    Resolution[] resolutions = new Resolution[23];


    public void OnPointerEnterBack()
    {
        isHovering = true;
        backButtonAnimator.SetBool("isHovering", isHovering);
        if(backButtonAnimator.GetBool("isHovering"))
        {
            Debug.Log("isHovering = ok");
        } else
        {
            Debug.LogWarning("Task failed Successfully");
        }
    }

    public void OnPointerExitBack()
    {
        isHovering = false;
        backButtonAnimator.SetBool("isHovering", isHovering);
        backButtonAnimator.SetTrigger("Reset");
        if (!backButtonAnimator.GetBool("isHovering"))
        {
            Debug.Log("isHovering = notOk");
        }
        else
        {
            Debug.LogWarning("Task failed Successfully");
        }
    }

    public void Back()
    {
        Debug.Log(animator.tag);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        animator.WriteDefaultValues();
    }

    public void SetVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("Quality Set to " + qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("FullScreen");
    }

    private void Start()
    {
        isHovering = false;
        PlayerPrefs.SetFloat("volume", 1f);
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        List<string> native = new List<string>();
        native.Add("Native Resolution");

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                nativeResolution.width = resolutions[i].width;
                nativeResolution.height = resolutions[i].height;
            }
        }

        resolutionDropdown.AddOptions(native);
        resolutionDropdown.AddOptions(options);
        try
        {
            resolutionDropdown.value = currentResolutionIndex + 1;
        }
        catch (IndexOutOfRangeException hell)
        {
            resolutionDropdown.value = exceptionResolutionIndex;
        }

        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionDropdown.value != 0)
        {
            try
            {
                Resolution resolution = resolutions[resolutionIndex];

                Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
                Debug.Log("Resolution changed to " + resolutionIndex);

            }
            catch (IndexOutOfRangeException hell)
            {
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                Debug.Log("Resolution was set to 22");
            }
        }

        if (resolutionDropdown.value == 0)
        {
            Screen.SetResolution(nativeResolution.width, nativeResolution.height, Screen.fullScreen);
            Debug.Log("Resolution set to " + nativeResolution.width + " x " + nativeResolution.height);
        }
    }
}
