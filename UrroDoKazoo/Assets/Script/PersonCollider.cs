using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCollider : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Entrou: " + gameObject.name + " + " + other.name);



	}

	void OnTriggerStay(Collider other) {

	}

	void OnTriggerExit(Collider other) {

	}
}
