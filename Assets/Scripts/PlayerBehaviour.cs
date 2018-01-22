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
    Image healthbar,shieldbar;
    Vector2 canvasHeight;


    [SerializeField]
    GameObject explosion, shieldExplosion;

    private float health;
    private readonly float maxHealth = 100;

    private float shield;
    private readonly float maxShield = 200;

    [SerializeField]
    public float shieldRegenTimer;
    float regenTimer;

    // Use this for initialization
    void Start () {
        player = gO.GetComponent<Transform>();
        health = maxHealth;
        shield = maxShield;
        canvasHeight = healthbar.GetComponent<RectTransform>().sizeDelta;
        regenTimer = Time.time;
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
        healthbar.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasHeight.x, (health / maxHealth) * canvasHeight.y);
        shieldbar.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasHeight.x, (shield / maxShield) * canvasHeight.y);

        if(shield < maxShield && Time.time > regenTimer)
        {
            regen(0.2f);
        }
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

    private void regen(float regen)
    {
        shield += regen;
        if(shield >= maxShield)
        {
            shield = maxShield;
        }

    }

    private void damage(float dmg)
    {
        regenTimer = Time.time + shieldRegenTimer;
        if(shield > 0.0f)
        {
            Instantiate(shieldExplosion, transform.position, Quaternion.identity);
            shield -= dmg;
            if(shield < 0)
            {
                shield = 0.0f;
            }
        }
        else
        {
            health -= dmg;
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (health < 0.0f)
            {
                health = 0.0f;
                //Death
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            Destroy(other.gameObject);
            damage(20);
        }
        else if (other.gameObject.tag.Equals("Mine"))
        {
            Destroy(other.gameObject);
            Handheld.Vibrate();
            damage(50);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Handheld.Vibrate();
            damage(100);
        }
    }
}
