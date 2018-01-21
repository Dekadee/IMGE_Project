using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {
    public GameObject player;

    public GameObject projectile;
    public Vector3[] projectileSpawnOffsets;

    public float shootingDelay=0.3f;

    public float maxRotationSpeed = 3;
    public float speed = 10;

    public float retreatDistance = 50;
    public int maxShotPerAttack = 3;

    private float lastShot=0;
    private int shotCount=0;

    private Renderer shipRenderer;

	// Use this for initialization
	void Start () {
        shipRenderer = GetComponentInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dif = player.transform.position - transform.position;
        float angleToPlayer = Vector3.SignedAngle(dif, transform.right, new Vector3(0, -1, 0));

        if (Mathf.Abs(angleToPlayer) < dif.magnitude && Time.time >= lastShot+shootingDelay && shipRenderer.isVisible){
            Shoot();
        }
        else if (!shipRenderer.isVisible){
            shotCount = 0;
        }

        float angleToRotate = angleToPlayer;
        if (Mathf.Abs(angleToPlayer)>=180 || shotCount>=maxShotPerAttack){
            Vector3 difRetreat=dif + player.transform.right*retreatDistance;
            angleToRotate=Vector3.SignedAngle(difRetreat, transform.right, new Vector3(0, -1, 0));
        }

        if (angleToRotate > maxRotationSpeed){
            angleToRotate = maxRotationSpeed;
        }
        else if (angleToRotate < -maxRotationSpeed){
            angleToRotate = -maxRotationSpeed;
        }

        transform.Rotate(new Vector3(0, angleToRotate, 0));

        transform.Translate(new Vector3(Time.deltaTime*speed,0,0));
	}

    void Shoot(){
        foreach (Vector3 offset in projectileSpawnOffsets)
        {
            Instantiate(projectile, transform.position + transform.rotation * offset, transform.rotation);
        }
        //Debug.Log("Shot "+shotCount);
        lastShot = Time.time;
        shotCount++;
    }
}
