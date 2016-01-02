using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Public Property
	public Transform target;
	public float camSpeed = 0.1f;

	// Private Poperty
	Camera myCam;

	// Use this for initialization
	void Start () {
		myCam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
		myCam.orthographicSize = (Screen.height / 100f) / 4f;

		// Cam follows player
		if (target) {
			transform.position = Vector3.Lerp(transform.position, target.position, camSpeed) + new Vector3(0, 0, -15);
		}
	}
}
