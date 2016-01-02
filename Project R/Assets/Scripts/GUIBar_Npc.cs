using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIBar_Npc : MonoBehaviour {

	public string messager = "_dummy_";
	private float minHealth, maxHealth;
	private GameObject npcObject;

	// Use this for initialization
	void Start () {
		npcObject = GameObject.Find("Demo_NPC_Damage").gameObject;
		minHealth = npcObject.GetComponent<ObjectSheet>().curr_hp;
		maxHealth = npcObject.GetComponent<ObjectSheet>().max_hp;
		setHpBarText();
	}

	// Update is called once per frame
	void Update () {
		minHealth = npcObject.GetComponent<ObjectSheet>().curr_hp;
		maxHealth = npcObject.GetComponent<ObjectSheet>().max_hp;
		setHpBarText();
	}

	public void setHpBarText() {
		GameObject msg = GameObject.Find("HealthBar/Text").gameObject;
		msg.GetComponent<Text>().text = minHealth + "/" + maxHealth;
	}
}
