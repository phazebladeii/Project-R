using UnityEngine;
using System.Collections;

public class TitleFade : MonoBehaviour {

	private GameObject parentObject, child, camera, playerObj;
	public float turnOffTime = 3f; // 3 seconds
	public float timeForControls = 5f; // 5 seconds

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("Main Camera").gameObject;

		playerObj = GameObject.Find("Player").gameObject;
		playerObj.GetComponent<PlayerMovement>().enabled = false; // Disable controls for the duration

		parentObject = GameObject.Find(gameObject.name); // Set Parent object

		child = parentObject.transform.Find("Image").gameObject; // Set Child
		child.SetActive(true);

		if (!parentObject.activeSelf) {
			print(parentObject.name + " is inactive");
			camera.GetComponent<AudioSource>().Play();
		} else { StartCoroutine("TitleOff"); StartCoroutine("ControlsOn"); }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ControlsOn() {
		yield return new WaitForSeconds(timeForControls);
		playerObj.GetComponent<PlayerMovement>().enabled = true; // Re-enable controls after the duration
	}

	public IEnumerator TitleOff() {
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
		yield return new WaitForSeconds(turnOffTime);
		yield return StartCoroutine(sf.FadeToBlack());
		child.SetActive(false);
		yield return StartCoroutine(sf.FadeToClear());
		camera.GetComponent<AudioSource>().Play();
	}
}
