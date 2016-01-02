using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

	public float interactDistance;
	public LayerMask interactLayer;
	private Animator _animator;
	private Vector2 _direction;
	// private bool cooldown = false;

	void Start () {
		_animator = GetComponent <Animator>();
	}

	// Update is called once per frame
	void Update () {
		_direction = new Vector2 (_animator.GetFloat("input_x"), _animator.GetFloat("input_y"));

		HandleInput();

	}

	public void HandleInput() {
		// Put input keys here
		if (Input.GetKeyDown (KeyCode.Z)) {
			PerformAction (_direction, 0);
		}

		if (Input.GetKeyDown(KeyCode.C)) {
			PerformAction (_direction, 1);
			_animator.SetTrigger("Attack");

			// StartCoroutine(TestCooldown());

		}

		if (Input.GetKeyDown(KeyCode.F)) {
			_animator.SetTrigger("Buff");
			SpellManager.Instance.CreateSpell(); // Instantiate the spell cast
		}
	}


	void PerformAction (Vector2 direction, int selection){
		RaycastHit2D hit = Physics2D.Raycast ((Vector2)transform.position + new Vector2 (0, transform.GetComponent<Collider2D>().bounds.size.y / 2), direction, interactDistance, interactLayer);
		if (hit) {
			ActionReciever receiver = hit.transform.GetComponent<ActionReciever> ();
			if (receiver) {
				receiver.SendActionMessage(selection);
			}
		}
	}

	/* 
	public IEnumerator TestCooldown() {
		cooldown = true;
		yield return new WaitForSeconds(0.1f);
		cooldown = false;
	}
	*/	

}
