using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassProvider : MonoBehaviour {

    private float heading = 0;

    private float oldHeading = 0;

    private float speed = 0.5f;

    [SerializeField]
    Text text;

    // Use this for initialization
    void Start () {
        Input.compass.enabled = true;
        Input.location.Start();
        Debug.Log("Compass initialized");
        heading = Input.compass.magneticHeading;
        oldHeading = Input.compass.magneticHeading;
    }
	
	// Update is called once per frame
	void Update () {

        heading = Input.compass.magneticHeading;

        //heading = oldHeading + 0.8f * (heading - oldHeading);

        //oldHeading = heading;

        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, heading, 0),speed );

        text.text = heading.ToString();
    }

    public float GetHeading()
    {
        return heading;
    }
}
