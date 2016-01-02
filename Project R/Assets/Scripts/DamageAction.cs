using UnityEngine;
using System.Collections;

public class DamageAction : MonoBehaviour {

	private GameObject damageObject;

	void ActionDamage() {

	}

	// Use this for initialization
	void Start () {
		damageObject = GameObject.Find(gameObject.name); // THIS object
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
