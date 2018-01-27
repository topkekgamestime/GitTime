using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCollider : MonoBehaviour {

	private Movement _move;

	void Start(){

		_move = gameObject.transform.parent.GetComponent<Movement> ();

	}


	void OnTriggerEnter(Collider other) {
		Debug.Log ("Entrou: " + gameObject.name + " + " + other.name);

		_move.VerificaColisao (gameObject.name, true);


	}

	void OnTriggerStay(Collider other) {

	}

	void OnTriggerExit(Collider other) {

		_move.VerificaColisao (gameObject.name, false);

	}
}
