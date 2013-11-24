using UnityEngine;
using System.Collections;

public class respounter : MonoBehaviour {

	public float spawnTime = 3f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts. [копипаста, да]
	public static bool On=true;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	void Spawn ()
	{
		if (On) {
			if (GameObject.FindGameObjectsWithTag("enemy").Length<5){
				Instantiate(enemy, transform.position, transform.rotation);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
