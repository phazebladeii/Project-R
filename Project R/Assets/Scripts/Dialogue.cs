using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour {

	public string msg = "Add text";
	private Text textMsg;
	// public float startDelay = 1f;
	public float typeDelay = 0.01f;


	// Use this for initialization
	void Start () {
		StartCoroutine("SpeechBox");
	}

	// Update is called once per frame
	void Update () {

	}

	void Awake() {
		textMsg = GetComponent<Text>();
	}

	public IEnumerator SpeechBox() {
		// yield return new WaitForSeconds(startDelay);

		for (int i = 0; i < msg.Length; i++) {
			textMsg.text = msg.Substring(0, i);
			yield return new WaitForSeconds(typeDelay);
		}

	}
}
