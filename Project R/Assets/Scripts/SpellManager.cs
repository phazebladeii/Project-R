using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour {

	private static SpellManager instance;

	public GameObject textPrefab;
	public RectTransform canvasTransform;

	public static SpellManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<SpellManager>();
			}

			return instance;
		}
	}

	public void CreateSpell() {

	}

}
