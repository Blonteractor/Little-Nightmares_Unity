using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TimeBody : MonoBehaviour
{
	public Light light = new Light();

    private bool isRewinding;
    public float recordTime = 5f;
    public float rewindTimeSpeed = 0.5f;
	public float lightEffectIntensity = 15f;
	[Space]
    [Header("Rewind Audio Properties")]
    [Range(0f, 1f)] public float rewindVolume;
    [Range(0f, 1f)] public float rewindPitch;

    List<PointInTime> pointsInTime;

    Rigidbody rb;
    [SerializeField] [Space]
    PlayerHealth playerHealth;
    GameObject player;
    AudioSource rewindTime;
    CapsuleCollider collider;

	private void Awake()
    {
        isRewinding = false;
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        rewindTime = GameObject.FindWithTag("Time Clip").GetComponent<AudioSource>();
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            RewindPrequisites();
            StartRewind();
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            RewindExquisites();
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if(isRewinding && !playerHealth.isDead)
        {
            Rewind();
        }

        if(!isRewinding && !playerHealth.isDead)
        {
            Record();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        if(rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void StopRewind()
    {
        isRewinding = false;
        if(rb != null)
        {
            rb.isKinematic = false;
        }
    }

    void Record()
    {
        if(pointsInTime.Count > Mathf.Round(recordTime /( Time.fixedDeltaTime * rewindTimeSpeed)))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, playerHealth.currentHealth));
        RewindExquisites();
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            playerHealth.currentHealth = pointInTime.playerHealth;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void RewindPrequisites()
    {
       // enemyManager.SetActive(false);
        collider.enabled = false;
        Time.timeScale = rewindTimeSpeed;
        rewindTime.PlayScheduled(3);
		StartCoroutine(LightEffectUp());
    }
    

    void RewindExquisites()
    {
        // enemyManager.SetActive(true);
        collider.enabled = true;
        Time.timeScale = 1f;
        rewindTime.Stop();
		StartCoroutine(LightEffectDown());
    }

	IEnumerator LightEffectUp()
	{
		while(true)
		{
			light.intensity++;

			if(light.intensity >= lightEffectIntensity)
			{
				break;
			}

			yield return null;
		}
	}

	IEnumerator LightEffectDown()
	{
		while (true)
		{
			light.intensity--;

			if (light.intensity <= 0.9)
			{
				light.intensity = 0.9f;
				break;
			}

			yield return null;
		}
	}
}
