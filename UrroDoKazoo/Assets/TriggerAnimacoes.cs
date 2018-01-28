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

		int random = Random.Range (1, 100);

		if (random < porcentagemAnim) {

			Animator anim = item.gameObject.GetComponentInChildren (typeof(Animator)) as Animator;

			if (gameObject.name == "TriggerAnimHumor") {
				anim.SetTrigger("humor");
			} else if (gameObject.name == "TriggerAnimTragedia") {
				anim.SetTrigger("tragedia");
			} else if (gameObject.name == "TriggerAnimFofo") {
				anim.SetTrigger("fofo");
			}
		}

	}

	void OnTriggerExit(Collider other){



	}

	void OntriggerStay(Collider other){

		Debug.Log ("Scrr");

	}


}

