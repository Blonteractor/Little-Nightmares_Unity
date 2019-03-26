using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    [Header("Animator References")]
    public Animator playButtonAnimator;
    public Animator optionsButtonAnimator;
    public Animator quitButtonAnimator;
    public Animator backButtonAnimator;

    private bool isHovering;

    private void Awake()
    {
        isHovering = false;
    }

    public void Quit()
    {
        Debug.Log("Application is quiting now...");
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level 01");
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

    }

    public void OnPointerEnterPlay()
    {
        isHovering = true;
        playButtonAnimator.SetBool("isHovering", true);
    }

    public void OnPointerExitPlay()
    {
        isHovering = false;
        playButtonAnimator.SetBool("isHovering", false);
        playButtonAnimator.SetTrigger("Reset");
    }

    public void OnPointerEnterBack()
    {
        isHovering = true;
        backButtonAnimator.SetBool("isHovering", true);
    }

    public void OnPointerExitBack()
    {
        isHovering = false;
        backButtonAnimator.SetBool("isHovering", false);
        backButtonAnimator.SetTrigger("Reset");
    }

    public void OnPointerEnterOptions()
    {
        isHovering = true;
        optionsButtonAnimator.SetBool("isHovering", true);
    }

    public void OnPointerExitOptions()
    {
        isHovering = false;
        optionsButtonAnimator.SetBool("isHovering", false);
        optionsButtonAnimator.SetTrigger("Reset");
    }

    public void OnPointerEnterQuit()
    {
        isHovering = true;
        quitButtonAnimator.SetBool("isHovering", true);
    }

    public void OnPointerExitQuit()
    {
        isHovering = false;
        quitButtonAnimator.SetBool("isHovering", false);
        quitButtonAnimator.SetTrigger("Reset");
    }
}
