using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {

	public Animator personAnim;
	public int pontosDaAnimacao = 50;
	public float segAteContarPontos = 0.5f;

	public GameObject hudManager;

	private HUDManamegent scriptHud;
	private Animator _personAnim;

	private float _segs;
	private string _ultimaAnimacao;

	private bool _fofoTriggered = false;
	private bool _tragicoTriggered = false;
	private bool _humorTriggered = false;


	void Start(){

		scriptHud = hudManager.GetComponent<HUDManamegent> (); 
		_personAnim = this.gameObject.GetComponentInChildren (typeof(Animator)) as Animator;

	}


	void Update()
	{

		if (this.GetComponent<Renderer> ().isVisible) {

			if (Camera.main.GetComponent<CameraController> ()._InZoom) {

				_segs += Time.deltaTime;

				if (_segs >= segAteContarPontos) {
					if (_personAnim.GetCurrentAnimatorStateInfo (0).IsName ("fofo")) {
						_fofoTriggered = true;
						_ultimaAnimacao = "fofo";
						AddPoint ("fofo",1.5f);
					} else if (_personAnim.GetCurrentAnimatorStateInfo (0).IsName ("tragedia")) {
						_tragicoTriggered = true;
						_ultimaAnimacao = "tragedia";
						AddPoint ("tragedia",1.5f);
					} else if (_personAnim.GetCurrentAnimatorStateInfo (0).IsName ("humor")) {
						_humorTriggered = true;
						_ultimaAnimacao = "humor";
						AddPoint ("humor",1.5f);
					} else {
						if (_ultimaAnimacao == "fofo" || _ultimaAnimacao == "tragedia" || _ultimaAnimacao == "humor") {
							if (_ultimaAnimacao == "fofo") {
								_fofoTriggered = false;
								_ultimaAnimacao = "";
								//AddPoint ("fofo",50);
							} else if (_ultimaAnimacao == "tragedia") {
								_tragicoTriggered = false;
								_ultimaAnimacao = "";
								//AddPoint ("tragedia",50);
							} else if (_ultimaAnimacao == "humor") {
								_humorTriggered = false;
								_ultimaAnimacao = "";
								//AddPoint ("humor",50);
							}
						}
					}
				}

			} else {
				Debug.Log ("Not visible");
			}
		}
	}

	void AddPoint(string tipo,float ponto){

		if (tipo == "fofo") {
			scriptHud.x += ponto;
			Debug.Log ("fofo ganhou um ponto");
		} else if (tipo == "tragedia") {
			scriptHud.z += ponto;
			Debug.Log ("tragedia ganhou um ponto");
		} else if (tipo == "humor") {
			scriptHud.y += ponto;
			Debug.Log ("humor ganhou um ponto");
		}

	}



}
