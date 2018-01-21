using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    Transform player;

    [SerializeField]
    GameObject gO;
    

    [SerializeField]
    Slider slider;

    [SerializeField]
    Image healthbar;
    Vector2 canvasHeight;

    [SerializeField]
    GameObject explosion;

    private float health;
    
	// Use this for initialization
	void Start () {
        player = gO.GetComponent<Transform>();
        health = 100.0f;
        canvasHeight = healthbar.GetComponent<RectTransform>().sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {
        #region WASD Movement

        if (Input.GetKey("w"))
        {
            player.Translate(new Vector3(1, 0, 0));
        }
        if (Input.GetKey("s"))
        {
            player.Translate(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey("a"))
        {
            player.Translate(new Vector3(0, 0, 1));
        }
        if (Input.GetKey("d"))
        {
            player.Translate(new Vector3(0, 0, -1));
        }
        #endregion

        player.Translate(slider.getSpeed()*10*Time.deltaTime, 0, 0);
        Debug.Log(health);
        healthbar.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasHeight.x, (health / 100.0f) * canvasHeight.y);
    }

    public void ResetPLayer()
    {
        health = 100.0f;
        player.position = new Vector3(0, 0, 0);
    }

    public void ResetPosition()
    {
        player.position = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion);
            health -= 20.0f;
            if(health < 0.0f)
            {
                health = 0.0f;
            }
        }
        else if (other.gameObject.tag.Equals("Mine"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion);
            health -= 50.0f;
            if (health < 0.0f)
            {
                health = 0.0f;
            }
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion);
            health -= 100.0f;
            if (health < 0.0f)
            {
                health = 0.0f;
            }
        }
    }
}
