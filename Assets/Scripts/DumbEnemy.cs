using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour {

    Vector3[] points;

    int nextTarget;

	// Use this for initialization
	void Start () {
        Vector2 rand = Random.insideUnitCircle * 100;
        transform.position = new Vector3(rand.x, 0, rand.y);
        points = new Vector3[5];
        nextTarget = 0;
        for(int i = 0;i < points.Length; i++)
        {
            Vector2 point2D = Random.insideUnitCircle * 50;
            points[i] = transform.position + new Vector3(point2D.x, 0, point2D.y);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if((transform.position - points[nextTarget]).magnitude < 5.0f){
            nextTarget++;
            nextTarget %= points.Length;
            
        }
        transform.position = Vector3.MoveTowards(transform.position, points[nextTarget], 10 * Time.deltaTime);
        Vector3 targetDir = points[nextTarget] - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10 * Time.deltaTime, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
