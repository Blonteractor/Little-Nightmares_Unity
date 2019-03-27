using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	private int spawnCount;
	private GameObject enemyManager;

	private void Awake()
	{
		
	}


	void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
		SkinnedMeshRenderer sr = enemy.GetComponentInChildren<SkinnedMeshRenderer>();
		sr.enabled = false;
		if(sr == null)
		{
			Debug.LogWarning("Renderer not found");
		}
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		spawnCount++;
	}
}
