using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MonoBehaviour {

    public GameObject target;

    bool circling = false;
    bool lockedOn = false;

    Vector3 returnPoint;

	// Use this for initialization
	void Start () {
        //Position wird zufällig bestimmt
        Vector2 rand = Random.insideUnitCircle * 100;
        transform.position = new Vector3(rand.x, 0, rand.y);
        target = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //Der Gegner folgt dem Spieler, wenn der Spieler in Reichweite ist
		if(((transform.position - target.transform.position).magnitude < 40.0f  || (lockedOn)) && !circling)
        {
            //Einmal gefunden, immer dran
            lockedOn = true;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
            Vector3 targetDir = target.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10 * Time.deltaTime, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            //Wenn der Gegner nah genug ist dreht er um und fängt aus einer neuen Richtung an
            if ((transform.position - target.transform.position).magnitude < 5.0f)
            {
                circling = true;
                Vector2 rand = Random.insideUnitCircle * 10;
                Vector3 offset = new Vector3(rand.x, 0, rand.y); //Zufalls punkt in einem Radius
                //Zufallspunkt wird in der entgegengestzten Richtung gestzt
                returnPoint = ((target.transform.position - transform.position)* -3) + transform.position + offset; 
            }
        } else if ((transform.position - returnPoint).magnitude < 1.0f) //Punkt zum Umdrehen gefunden
        {
            circling = false;
        } else
        {   
            //Gegner bewegt sich zu seinem festgelegtem Punkt
            if (lockedOn)
            {
                transform.position = Vector3.MoveTowards(transform.position, returnPoint, 10 * Time.deltaTime);
                Vector3 targetDir = returnPoint - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10 * Time.deltaTime, 0.0F);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
        }
	}
}
