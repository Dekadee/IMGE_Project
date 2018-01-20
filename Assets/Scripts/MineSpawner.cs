using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

    [SerializeField]
    GameObject minePrefab;

	// Use this for initialization
	void Start () {
		for(int i = 0;i < 300; i++)
        {
            GameObject go =  Instantiate(minePrefab);
            Vector2 rand = Random.insideUnitCircle * 200;
            go.transform.position = new Vector3(rand.x, 0, rand.y);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
