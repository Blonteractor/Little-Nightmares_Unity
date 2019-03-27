using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
	
	[Header("Wave Settings")]
	public int increaseEnemyBy = 2;
	public int maxEnemyCount = 3;
	public int waitTime = 20;

	public float spawnTime = 3f;
	
    public Transform[] spawnPoints;

	[HideInInspector] public int spawnCount;
	private GameObject enemyManager;
	[SerializeField] private bool isSpawning;
	private bool flag;

	private void Awake()
	{
		isSpawning = true;
		flag = false;
	}
	
	private void Update()
	{
		if (!isSpawning && !flag)
		{
			spawnCount = 0;
			flag = true;
			maxEnemyCount += increaseEnemyBy;
			InvokeRepeating("Spawn" , waitTime , spawnTime);
		}
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
		isSpawning = true;
		flag = false;

        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		spawnCount++;
		Debug.Log(spawnCount);

		if (spawnCount >= maxEnemyCount)
		{
			isSpawning = false;
			CancelInvoke();
			return;
		}
	}
}
