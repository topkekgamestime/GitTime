using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float Speed = 2.0f;
	public float Pace = 2.0f;

	public Vector3 initialPosition;

	public Animator personAnim;
	private Transform _trGraphics;
	private Transform _tr;
	private Vector3 _pos;

	private int _direcao = 1; //1 - frente, 2 - cima, 3 - atras, 4 - baixo

	private bool _flagFrente = false;
	private bool _flagCima = false;
	private bool _flagAtras = false;
	private bool _flagBaixo = false;

	private Animator _personAnim;

	// Use this for initialization
	void Start () {

		//_personAnim = gameObject.GetComponent<Animator> ();
		_personAnim = this.gameObject.GetComponentInChildren(typeof(Animator)) as Animator;
		_trGraphics = this.gameObject.transform.GetChild(4).transform;
		_tr = gameObject.transform;
		_direcao = Random.Range (1, 4);
		//_personAnim.SetTrigger("humor");

		//StartCoroutine (Walk());

	}
	
	// Update is called once per frame
	void Update () {


	}

	IEnumerator Walk(){

		while (_direcao != 0) {
			bool numComColisao = true;

			// Verifica colisao com o número se o num tiver colisao ele rondomiza o numero e faz de novo
			while (numComColisao) {
				if ((_direcao == 1 && _flagFrente) || (_direcao == 2 && _flagCima) || (_direcao == 3 && _flagAtras) || (_direcao == 4 && _flagBaixo)) {
					_direcao = Random.Range (1, 4);
					Debug.Log ("Troca");
				} else {
					numComColisao = false;
				}

			}
							
				if (_direcao == 1) {
					_pos += Vector3.right * Pace;
					_trGraphics.localScale = new Vector3(-3,3,1);
				} else if (_direcao == 2) {
					_pos += Vector3.left * Pace;
				} else if (_direcao == 3) {
					_pos += Vector3.forward * Pace;
					_trGraphics.localScale = new Vector3(3,3,1);
				} else if (_direcao == 4) {
					_pos += Vector3.back * Pace;
				} else {
					_direcao = 0;
				}

					transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * Speed);
			//}
			//}

			yield return new WaitForSeconds(0.5f);

		}

	}

	// funcao que muda a direção caso entre em colisão com algo

	public void VerificaColisao(string name, bool colidiu) {

		if (name == "TriggerFront") {
			if (colidiu) {
				_flagFrente = true;
			} else {
				_flagFrente = false;
			}
		} else if (name == "TriggerBack") {
			if (colidiu) {
				_flagAtras = true;
			} else {
				_flagAtras = false;
			}
		} else if (name == "TriggerUp") {
			if (colidiu) {
				_flagCima = true;
			} else {
				_flagCima = false;
			}
		} else if (name == "TriggerDown") {
			if (colidiu) {
				_flagBaixo = true;
			} else {
				_flagBaixo = false;
			}
		}
	}

}