using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject dumbEnemyPrefab;
    [SerializeField]
    GameObject smartEnemyPrefab;
    [SerializeField]
    GameObject player;

    private readonly int START_ENEMY_DUMB = 20;

    private readonly int START_ENEMY_SMART = 20;

    // Use this for initialization
    void Start () {

		for(int i = 0;i < START_ENEMY_DUMB; i++)
        {
            Instantiate(dumbEnemyPrefab);
        }


        for (int i = 0; i < START_ENEMY_SMART; i++)
        {
            Instantiate(smartEnemyPrefab);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
