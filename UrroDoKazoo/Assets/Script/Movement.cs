using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float Speed = 2.0f;

	public Vector3 initialPosition;

	private Transform _tr;
	private Vector3 _pos;

	private int _direcao = 1; //1 - frente, 2 - cima, 3 - atras, 4 - baixo

	// Use this for initialization
	void Start () {

		_tr = gameObject.transform;

	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine (Walk());

		//_direcao = Random.Range (1, 4);

		if (VerificaColisao (_direcao)) {

			//StartCoroutine (Walk (_direcao));
			
			/*if (_direcao == 1 && _tr.position == _pos) {
				_pos += Vector3.right;
			}
			else if (_direcao == 2 && _tr.position == _pos) {
				_pos += Vector3.left;
			}
			else if (_direcao == 3 && _tr.position == _pos) {
				_pos += Vector3.forward;
			}
			else if (_direcao == 4 && _tr.position == _pos) {
				_pos += Vector3.back;
			}

			transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * Speed);*/

		}

	}


	bool VerificaColisao(int num) {

		if (num == 1) {

		} else if (num == 2) {

		} else if (num == 3) {

		} else {

		}

		return true;

	}

	IEnumerator Walk(){

		while (_direcao != 0) {

			_direcao = Random.Range (1, 4);

			Debug.Log (_direcao);

			if (_direcao == 1 && _tr.position == _pos) {
				_pos += Vector3.right;
			} else if (_direcao == 2 && _tr.position == _pos) {
				_pos += Vector3.left;
			} else if (_direcao == 3 && _tr.position == _pos) {
				_pos += Vector3.forward;
			} else if (_direcao == 4 && _tr.position == _pos) {
				_pos += Vector3.back;
			} else {
				_direcao = 0;
			}

			transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * Speed);


			yield return new WaitForSeconds(1.0f);

		}

	}



}