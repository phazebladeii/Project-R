using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC_Object : MonoBehaviour {

	private GameObject parentObject, playerObj;
	private GameObject child, childHp;
	private bool notKillable = false;
	private Text textChild;
	public float turnOffTime = 4f; // 4 seconds

	// Use this for initialization
	void Start () {

		playerObj = GameObject.Find("Player");
		parentObject = GameObject.Find(gameObject.name); // Set Parent object
		child = parentObject.transform.Find("DialogueBox").gameObject; // Set Child
		child.SetActive(false); // Dialogue should start invisible

		if (parentObject.transform.Find("HealthBar") == null) {
			notKillable = true;
		}

	}

	public void Action(int a) {
		if (a == 0) {

			textChild = parentObject.transform.Find("DialogueBox/SpeechBubble/Text").gameObject.GetComponent<Text>();

			if (textChild.text == "enemy") {
				// Do nothing since it's a killable NPC
			} else {
				child.SetActive(true);
				StartCoroutine("SpeechOff");
			}
		}

		if (a == 1 && notKillable == false) {

			// !! Player damage calculation goes here !!
				
			float p_min = playerObj.GetComponent<PlayerSheet>().min_dam;
			float p_max = playerObj.GetComponent<PlayerSheet>().max_dam;

			float e_min = parentObject.GetComponent<ObjectSheet>().min_dam;
			float e_max = parentObject.GetComponent<ObjectSheet>().max_dam;

			float p_damage = Mathf.Round(Random.Range(p_min, p_max));
			string playerDam = p_damage.ToString();
			bool playerCrit = false;

			// !! Enemy damage calculation goes here !!
			float e_damage = Mathf.Round(Random.Range(e_min, e_max));
			string enemyDam = e_damage.ToString();
			bool enemyCrit = false;

			// !! Change color based on value here !!
			Color playerColor = Color.white;
			Color enemyColor = Color.white;

			if (p_damage >= 27f) {
				playerColor = Color.red;
				playerCrit = true;
			}

			if (e_damage >= 23f) {
				enemyColor = Color.red;
				enemyCrit = true;
			}
		
			// !! Add damage text here !!
			CombatTextManager.Instance.CreateText(parentObject.transform.position, playerDam, playerColor, playerCrit); // !! You apply YOUR damage to the enemy !!
			CombatTextManager.Instance.CreateText(playerObj.transform.position, enemyDam, enemyColor, enemyCrit); // !! The enemy applies THEIR damage to you !!
			gameObject.GetComponent<ObjectSheet>().decreaseHp(p_damage);
			playerObj.GetComponent<PlayerSheet>().decreaseHp(e_damage);

		}

	}

	public IEnumerator SpeechOff() {
		yield return new WaitForSeconds(turnOffTime);
		child.SetActive(false);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
