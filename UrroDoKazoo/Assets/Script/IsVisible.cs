using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {

	public Animator personAnim;

	public AudioClip feliz;
	public AudioClip tragico;
	public AudioClip humor;

	//public int pontosDaAnimacao = 50;
	public float segAteContarPontos = 0.5f;

	public float PontosPorSegundos = 1.5f;

	public GameObject hudManager;

	private HUDManamegent scriptHud;
	private Animator _personAnim;

	private float _segs;
	private string _ultimaAnimacao;

	private bool _fofoTriggered = false;
	private bool _tragicoTriggered = false;
	private bool _humorTriggered = false;

	private bool _audio;


	void Start(){

		scriptHud = hudManager.GetComponent<HUDManamegent> (); 
		_personAnim = this.gameObject.GetComponentInChildren (typeof(Animator)) as Animator;

	}


	void Update()
	{

		//Debug.Log (EstaTocandoAudio () + " Bool");

		//AudioSource.PlayClipAtPoint (feliz);

		if (this.GetComponent<Renderer> ().isVisible) {

			if (Camera.main.GetComponent<CameraController> ()._InZoom) {

				_segs += Time.deltaTime;

				if (_segs >= segAteContarPontos) {
					if (_personAnim.GetCurrentAnimatorStateInfo (0).IsName ("fofo")) {
						_fofoTriggered = true;
						_ultimaAnimacao = "fofo";
						AddPoint ("fofo",PontosPorSegundos);
						_personAnim.SetBool("pFofo",true);

					} else if (_personAnim.GetCurrentAnimatorStateInfo (0).IsName ("tragedia")) {
						_tragicoTriggered = true;
						_ultimaAnimacao = "tragedia";
						AddPoint ("tragedia",PontosPorSegundos);
						_personAnim.SetBool("pTragedia",true);

					} else if (_personAnim.GetCurrentAnimatorStateInfo (0).IsName ("humor")) {
						_humorTriggered = true;
						_ultimaAnimacao = "humor";
						AddPoint ("humor",PontosPorSegundos);
						_personAnim.SetBool("pHumor",true);

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
                _personAnim.SetBool("pFofo", false);
                _personAnim.SetBool("pTragedia", false);
                _personAnim.SetBool("pHumor", false);
                Debug.Log ("Not visible");
			}
		}
	}

	void AddPoint(string tipo,float ponto){

		if (tipo == "fofo") {
			if (scriptHud.x <= 100) {
				scriptHud.x += ponto;
				Debug.Log ("fofo ganhou um ponto");
			}
		} else if (tipo == "tragedia") {
			if (scriptHud.z <= 100) {
				scriptHud.z += ponto;
				Debug.Log ("tragedia ganhou um ponto");
			}
		} else if (tipo == "humor") {
			if (scriptHud.y <= 100) {
				scriptHud.y += ponto;
				Debug.Log ("humor ganhou um ponto");
			}
		}

	}

	bool EstaTocandoAudio() {
		Transform audio = gameObject.transform.parent.Find ("One_shot_audio");

		if (audio.name == null) {
			return true;
		} else {
			return false;
		}
	}



}
