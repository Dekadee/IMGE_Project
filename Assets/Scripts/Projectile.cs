using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed=1.0f;
    public Vector3 direction = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            ScoreKeeping.score += 20;
            other.gameObject.GetComponent<EnemyInterface>().Damage(50);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("Mine")){
            ScoreKeeping.score += 5;
            Destroy(other.gameObject);
            //Instantiate() Explosion
            Destroy(gameObject);
        }
    }
}
