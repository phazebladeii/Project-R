﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour {

	private static CombatTextManager instance;

	public GameObject textPrefab;
	public RectTransform canvasTransform;
	public float speed, fadeTime;
	public Vector3 direction;

	public static CombatTextManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<CombatTextManager>();
			}

			return instance;
		}
	}


	public void CreateText(Vector3 position, string text, Color color, bool crit) {
		GameObject sct = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);

		sct.transform.SetParent(canvasTransform);
		sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
		sct.GetComponent<CombatText>().Init(speed, direction, fadeTime, crit);
		sct.GetComponent<Text>().text = text;
		sct.GetComponent<Text>().color = color;
	}




}
