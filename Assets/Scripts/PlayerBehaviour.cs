using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Transform player;

    [SerializeField]
    GameObject gO;

    [SerializeField]
    Slider slider;
    
	// Use this for initialization
	void Start () {
        player = gO.GetComponent<Transform>();
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
    }

    public void ResetPosition()
    {
        player.position = new Vector3(0, 0, 0);
    }
}
