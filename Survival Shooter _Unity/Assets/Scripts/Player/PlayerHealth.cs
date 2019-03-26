using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    [HideInInspector]
    public int currentHealth;

    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;

    public float flashSpeed = 5f;
    public float gameOverWaitTime = 5f;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private Animator anim;
    private AudioSource playerAudio;
    private PlayerMovement playerMovement;
    private PlayerShooting playerShooting;

    [HideInInspector] public bool isDead;
    private bool damaged;
    [SerializeField] private bool isMainMenu;

    void Awake ()
    {
        isMainMenu = false;
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            MainMenu();
        }

        damaged = false;

        healthSlider.value = currentHealth;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {    
            
        Invoke("Restart", gameOverWaitTime);
                               
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MainMenuLoader()
    {
        if(isDead && isMainMenu)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
          
        }
    }

    public void MainMenu()
    {
        Debug.Log("pressed");
        isMainMenu = true;
        CancelInvoke();
        MainMenuLoader();
    }

}
