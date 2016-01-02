using UnityEngine;
using System.Collections;

public class ActionReciever_Damage : MonoBehaviour {

	public void SendActionMessage() {

		gameObject.SendMessage("ActionDamage", SendMessageOptions.DontRequireReceiver);

	}
}
