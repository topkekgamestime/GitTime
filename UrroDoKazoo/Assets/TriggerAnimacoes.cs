using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimacoes : MonoBehaviour {

	public int porcentagemAnim;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void OnTriggerEnter(Collider other){

		int random = Random.Range (1, 100);

		if (random < porcentagemAnim) {

			Debug.Log ("AAAS");

			if (gameObject.name == "TriggerAnimHumor") {
				other.gameObject.GetComponent<Animator> ().SetTrigger ("humor");
				other.gameObject.GetComponent<Movement> ().ExecutaAnimacoes ("humor");
			} else if (gameObject.name == "TriggerAnimTragedia") {
				other.gameObject.GetComponent<Animator> ().SetTrigger ("tragedia");
				other.gameObject.GetComponent<Movement> ().ExecutaAnimacoes ("tragedia");
			} else if (gameObject.name == "TriggerAnimFofo") {
				other.gameObject.GetComponent<Animator> ().SetTrigger ("fofo");
				other.gameObject.GetComponent<Movement> ().ExecutaAnimacoes ("fofo");
				//personAnim.SetBool ("moving", true);
			}
		}

	}

	void OnTriggerExit(Collider other){



	}

	void OntriggerStay(Collider other){

		Debug.Log ("Scrr");

	}


}

