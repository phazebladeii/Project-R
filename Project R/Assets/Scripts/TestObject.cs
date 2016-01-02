using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestObject : MonoBehaviour {

	private GameObject parentObject;
	private GameObject child;
	public float turnOffTime = 4f;

	// Use this for initialization
	void Start () {
		parentObject = GameObject.Find("Demo_NPC");
		child = parentObject.transform.Find("DialogueBox").gameObject;
		child.SetActive(false);

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Action() {
		// print("This function is working");
		child.SetActive(true);
		StartCoroutine("TurnOff");

	}

	public IEnumerator TurnOff() {
		yield return new WaitForSeconds(turnOffTime);
		child.SetActive(false);

	}


}
