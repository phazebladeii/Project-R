using UnityEngine;
using System.Collections;

public class PlayerSheet : MonoBehaviour {

	public float max_hp = 100f;
	public float curr_hp = 0f;
	public GameObject bar;

	// Use this for initialization
	void Start () {
		curr_hp = max_hp;
		// InvokeRepeating("decreaseHp", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void decreaseHp() {
		// curr_hp -= 3f;
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
