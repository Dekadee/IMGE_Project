using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    GameObject followed;
    [SerializeField]
    float zOffset = 0.0f;
    [SerializeField]
    float xOffset = 3.0f;
    [SerializeField]
    float yOffset = 10.0f;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(3, 10, 0);
        transform.position = followed.transform.position + followed.transform.rotation*offset;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                              followed.transform.eulerAngles.y + 90,
                                              transform.rotation.eulerAngles.z);
	}

    // Update is called once per frame
    void LateUpdate () {
        transform.position = followed.transform.position + followed.transform.rotation*offset;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                              followed.transform.eulerAngles.y + 90,
                                              transform.rotation.eulerAngles.z);
    }
}
