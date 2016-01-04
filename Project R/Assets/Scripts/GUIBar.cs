using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIBar : MonoBehaviour {

	public string message = "_dummy_";
	private float playerHealth, maxHealth;
	private GameObject playerObj;

	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find("Player").gameObject;
		playerHealth = playerObj.GetComponent<PlayerSheet>().curr_hp;
		maxHealth = playerObj.GetComponent<PlayerSheet>().max_hp;
		setHpBarText();
	}

	// Update is called once per frame
	void Update () {
		playerHealth = playerObj.GetComponent<PlayerSheet>().curr_hp;
		maxHealth = playerObj.GetComponent<PlayerSheet>().max_hp;
		setHpBarText();
	}

	public void setHpBarText() {
		GameObject msg = GameObject.Find("HealthBar/Text").gameObject;
		msg.GetComponent<Text>().text = Mathf.Round(playerHealth) + "/" + Mathf.Round(maxHealth);
	}
}
