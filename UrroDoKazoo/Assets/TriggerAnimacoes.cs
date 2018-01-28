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

		GameObject item = other.gameObject;

		if (other.name != "Figurante") {
			item = other.gameObject.transform.parent.gameObject;
		}

		//if (other.tag == "Figurante") {
		int random = Random.Range (1, 100);

		if (random < porcentagemAnim) {

			if (gameObject.name == "TriggerAnimHumor") {
				item.gameObject.GetComponent<Animator> ().SetTrigger ("humor");
				item.gameObject.GetComponent<Movement> ().ExecutaAnimacoes ("humor");
			} else if (gameObject.name == "TriggerAnimTragedia") {
				item.gameObject.GetComponent<Animator> ().SetTrigger ("tragedia");
				item.gameObject.GetComponent<Movement> ().ExecutaAnimacoes ("tragedia");
			} else if (gameObject.name == "TriggerAnimFofo") {
				item.gameObject.GetComponent<Animator> ().SetTrigger ("fofo");
				item.gameObject.GetComponent<Movement> ().ExecutaAnimacoes ("fofo");
					//personAnim.SetBool ("moving", true);
			}
		}
		//}

	}

	void OnTriggerExit(Collider other){



	}

	void OntriggerStay(Collider other){

		Debug.Log ("Scrr");

	}


}

