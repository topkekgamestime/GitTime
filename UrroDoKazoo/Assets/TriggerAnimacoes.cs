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

			if (gameObject.name == "TriggerAnimHumor") {
				Debug.Log("AnimacaoHumor");
			} else if (gameObject.name == "TriggerAnimTragedia") {
				Debug.Log("AnimacaoTragedia");
			} else if (gameObject.name == "TriggerAnimFofo") {
				Debug.Log("AnimacaoFofo");
			}
		}

	}

	void OnTriggerExit(Collider other){

	}

	void OntriggerStay(Collider other){

	}


}

