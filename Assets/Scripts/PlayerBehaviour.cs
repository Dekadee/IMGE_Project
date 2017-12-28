using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Transform player;
    
	// Use this for initialization
	void Start () {

        player = gameObject.GetComponent<Transform>();


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

        transform.Translate(10*Time.deltaTime, 0, 0);
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
