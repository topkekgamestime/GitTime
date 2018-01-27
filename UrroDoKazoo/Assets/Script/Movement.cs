﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float Speed = 2.0f;

	public Vector3 initialPosition;

	public GameObject ColliderCima;
	public GameObject ColliderBaixo;
	public GameObject ColliderFrente;
	public GameObject ColliderTras;

	private Transform _tr;
	private Vector3 _pos;

	private int _direcao; //1 - frente, 2 - cima, 3 - atras, 4 - baixo

	// Use this for initialization
	void Start () {

		_tr = gameObject.transform;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.A) && _tr.position == _pos) {
			_pos += Vector3.right;
		}
		else if (Input.GetKeyDown(KeyCode.D) && _tr.position == _pos) {
			_pos += Vector3.left;
		}
		else if (Input.GetKeyDown(KeyCode.S) && _tr.position == _pos) {
			_pos += Vector3.forward;
		}
		else if (Input.GetKeyDown(KeyCode.W) && _tr.position == _pos) {
			_pos += Vector3.back;
		}

		transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * Speed);

	}

	void checkCollision(Collider other) {

		ColliderCima.GetComponent<BoxCollider> ();


	}

	void OnTriggerEnter(Collider other){


	}

	void OnTriggerStay(Collider other){

	}

	void OnTriggerExit(Collider other){

	}
}


/*private var speed = 2.0;
private var pos : Vector3;
private var tr : Transform;

function Start() {
	pos = transform.position;
	tr = transform;
}

function Update() {

	if (Input.GetKeyDown(KeyCode.D) && tr.position == pos) {
		pos += Vector3.right;
	}
	else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos) {
		pos += Vector3.left;
	}
	else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos) {
		pos += Vector3.up;
	}
	else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos) {
		pos += Vector3.down;
	}

	transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
}*/