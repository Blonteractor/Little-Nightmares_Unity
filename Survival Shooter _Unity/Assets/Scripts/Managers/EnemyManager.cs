using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;

    public float spawnTime = 3f;
	public int maxEnemyCount = 3;
	public int waitTime = 20;
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
