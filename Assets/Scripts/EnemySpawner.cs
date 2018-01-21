using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject dumbEnemyPrefab;
    [SerializeField]
    GameObject smartEnemyPrefab;
    [SerializeField]
    GameObject shootingEnemy;

    private readonly int START_ENEMY_DUMB = 20;

    private readonly int START_ENEMY_SMART = 20;

    private readonly int START_ENEMY_SHOOTING = 5;


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

        for (int i = 0; i < START_ENEMY_SHOOTING; i++)
        {
            Instantiate(shootingEnemy);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
