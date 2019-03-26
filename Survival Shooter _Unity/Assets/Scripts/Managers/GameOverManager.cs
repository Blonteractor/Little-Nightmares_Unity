using UnityEngine;
using UnityEngine.Audio;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public AudioSource BG;

    private AudioSource gameOverClip; 
    private Animator anim;


    void Awake()
    {
        gameOverClip = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("gameOver");
            Invoke("PlayAudio", 1f);
        }
    }

    void PlayAudio()
    {
        gameOverClip.Play();
        BG.Stop();
    }
}
