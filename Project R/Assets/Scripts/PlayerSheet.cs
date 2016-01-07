using UnityEngine;
using System.Collections;

public class PlayerSheet : MonoBehaviour {

	public float max_hp = 100f, curr_hp = 0f;
	public float min_dam = 5f, max_dam = 12f;
	public float critChance = 0.05f; // 5% base crit chance
	public float critMultiplier = 1f;
	public GameObject bar;

	// Use this for initialization
	void Start () {
		curr_hp = max_hp;
		// InvokeRepeating("decreaseHp", 1f, 1f); !! FOR DEBUG !!
	}

	// Update is called once per frame
	void Update () {

		// If there is no health left, destroy the game object -- figure out for player
		if (curr_hp <= 0) {
			curr_hp = 0;
			Destroy(transform.root.gameObject);

		}

		if (curr_hp < max_hp) { curr_hp += 0.05f; } // !! FOR DEBUG !!


		setHealthBar(curr_hp / max_hp);
	}

	public void decreaseHp(float amount) {
		curr_hp -= amount;
		float calc_hp = curr_hp / max_hp;
		setHealthBar(calc_hp);
	}

	public void setHealthBar(float health) {
		bar.transform.localScale = new Vector3
			(Mathf.Clamp(health, 0f, 1f), 
				bar.transform.localScale.y, 
				bar.transform.localScale.z);
	}
}
