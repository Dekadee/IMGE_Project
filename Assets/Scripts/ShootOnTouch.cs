﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnTouch : MonoBehaviour {

    public GameObject projectile;
    public Vector3[] spawnOffsets;
    public Vector3[] extraSpawnOffstes;

    private int touchCount;

	// Use this for initialization
	void Start () {
        touchCount = Input.touchCount;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.touchCount > touchCount || Input.GetKey("space")){
            foreach (Vector3 offset in spawnOffsets){
                Instantiate(projectile, transform.position + transform.rotation * offset, transform.rotation);
            }
        }
        if (ScoreKeeping.score > 200)
        {
            if (Input.touchCount > touchCount || Input.GetKey("space"))
            {
                foreach (Vector3 offset in extraSpawnOffstes)
                {
                    Instantiate(projectile, transform.position + transform.rotation * offset, transform.rotation);
                }
            }
        }
        touchCount = Input.touchCount;
	}
}
