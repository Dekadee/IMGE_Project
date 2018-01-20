using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector2 rand = Random.insideUnitCircle * 100;
        gameObject.transform.position = new Vector3(rand.x, 0, rand.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
