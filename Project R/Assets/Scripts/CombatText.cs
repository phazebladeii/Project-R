using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatText : MonoBehaviour {

	private float speed, fadeTime;
	private Vector3 direction;
	public AnimationClip critAnim;
	private bool crit;

	
	// Update is called once per frame
	void Update () {

		if (!crit) {
			float translation = speed * Time.deltaTime;

			transform.Translate(direction * translation);
		}


	}

	public void Init(float speed, Vector3 dir, float fade, bool crit) {
		this.fadeTime = fade;
		this.speed = speed;
		this.direction = dir;
		this.crit = crit;

		if (crit) {
			GetComponent<Animator>().SetTrigger("Critical");
			StartCoroutine(Critical());
		} else {
			StartCoroutine(Fadeout());
		}

	}

	private IEnumerator Critical() {
		yield return new WaitForSeconds(critAnim.length);
		crit = false;
		StartCoroutine(Fadeout());
	}


	private IEnumerator Fadeout() {
		float startAlpha = GetComponent<Text>().color.a;
		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.0f) { 
			Color tempColor = GetComponent<Text>().color;

			GetComponent<Text>().color = new Color
				(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(startAlpha, 0, progress));
		
			progress += rate * Time.deltaTime;

			yield return null;
		}

		Destroy(gameObject);
	}

}
