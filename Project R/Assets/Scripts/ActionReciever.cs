using UnityEngine;
using System.Collections;

public class ActionReciever : MonoBehaviour {

	public void SendActionMessage(int choice){

		gameObject.SendMessage("Action", choice, SendMessageOptions.DontRequireReceiver);

	}
}
