using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footsteps;
    public Rigidbody playerRigidbody;

    [SerializeField] private float audioLagTime;

    public void FootstepsEvent()
    {
        footsteps.Play();
    }
    
    public void FootstepsEventStop()
    {
        Invoke("What", audioLagTime);
    }

    void What()
    {
        footsteps.Pause();
    }
}
