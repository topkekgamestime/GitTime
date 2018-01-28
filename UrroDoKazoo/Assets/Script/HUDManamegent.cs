﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManamegent : MonoBehaviour {

	[Range(0,100)]
	public float x;
	[Range(0,100)]
	public float y;
	[Range(0,100)]
	public float z;
	[Range(0,9999999)]
	public float money = 0.0f;
	[Range(0,9999999)]
	public int realmoney = 0;
	public Text kazoos;
	[Range(0,100)]
	public int caos;
	[Range(0,100)]
	public float aud;

	public Slider Fofo;
	public Slider Humor;
	public Slider Treta;
	public Slider Aud;
	public Animator AudAnim;

	public float PontosPerdidosPorSegundo = 0.1f;
	public float TempoEntrePontosPerdidos = 0.5f; // zero perde por frame

	public bool ChaosPorTempo = false;
	public float ChaosMultiplier = 1.0f;
	public float ChaosTimeIncrease = 5.0f;
	public float ChaosIncrease = 1.0f;

	// Use this for initialization
	void Start () {

		Fofo.value = 35.0f;
		Humor.value = 35.0f;
		Treta.value = 35.0f;

		StartCoroutine (PerderPonto ());
		StartCoroutine (AumentarChaos ());

	}
	
	// Update is called once per frame
	void Update () {
		money = (32*(75*x + 95*y + 140*z) + 3*(x+y+z+56*(x+y)/27))-347951;
		realmoney = Mathf.RoundToInt (money);
		aud = (x + y + z) / 3;
		Fofo.value = x;
		Humor.value = y;
		Treta.value = z;
		Aud.value = aud;
		AudAnim.SetFloat("value", Aud.value);
		kazoos.text = realmoney.ToString();

		if(Input.GetKeyDown("escape") || Input.GetKeyDown("space"))
		{
			SceneManager.LoadScene (3);
				Debug.Log("Pause");
		}

		if (x == 0 || y == 0 || z == 0) {
			Debug.Log ("Perdeu lixo");
		}

		if (aud < 0) {
			SceneManager.LoadScene (5);

		}
	}


	IEnumerator PerderPonto(){
		int j = 0;

		while (j == 0) {

			if (ChaosPorTempo) {

				x -= PontosPerdidosPorSegundo;
				y -= PontosPerdidosPorSegundo;
				z -= PontosPerdidosPorSegundo;

			} else {

				x -= PontosPerdidosPorSegundo * ChaosMultiplier;
				y -= PontosPerdidosPorSegundo * ChaosMultiplier;
				z -= PontosPerdidosPorSegundo * ChaosMultiplier;
			}

			yield return new WaitForSeconds (TempoEntrePontosPerdidos);
		}
	}

	IEnumerator AumentarChaos(){
		int j = 0;

		while (j == 0) {

			ChaosMultiplier += ChaosIncrease;

			if (ChaosPorTempo) {
				TempoEntrePontosPerdidos -= ChaosMultiplier;
			}

			yield return new WaitForSeconds (ChaosTimeIncrease);
		}
	}
}
