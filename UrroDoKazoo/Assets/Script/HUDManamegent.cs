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
	public AudioClip Corta;

	public GameObject Voltamos;
	public bool IsPaused = false;
	public GameObject hud01;
	public GameObject hud02;
	public GameObject hud03;
	public GameObject pausemenu;


	public Slider Fofo;
	public Slider Humor;
	public Slider Treta;
	public Slider Aud;
	public Animator AudAnim;

	public float PontosPerdidosPorSegundo = 0.1f;
	public float TempoEntrePontosPerdidos = 1.0f; // zero perde por frame

	public bool ChaosPorTempo = false;
	public float ChaosMultiplier = 1.0f;
	public float ChaosTimeIncrease = 5.0f;
	public float ChaosIncrease = 1.0f;
	public float LimiteChaos = 100f;

	private float _money;

	// Use this for initialization
	void Start () {

		Fofo.value = 35.0f;
		Humor.value = 35.0f;
		Treta.value = 35.0f;

		StartCoroutine (PerderPonto ());
		StartCoroutine (AumentarChaos ());
		StartCoroutine (Dinheiro ());

	}

	IEnumerator Espera(){
		{
			yield return new WaitForSecondsRealtime(3.2f);
			hud01.SetActive (true);
			hud02.SetActive (true);
			hud03.SetActive (true);

			pausemenu.SetActive (false);

			Time.timeScale = 1;
			gameObject.GetComponent<Blink> ()._pause = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		realmoney = Mathf.RoundToInt (_money);
		aud = (x + y + z) / 3;
		Fofo.value = x;
		Humor.value = y;
		Treta.value = z;
		Aud.value = aud;
		AudAnim.SetFloat("value", Aud.value);
		kazoos.text = realmoney.ToString();

		if(Input.GetKeyDown("escape") || Input.GetKeyDown("space"))
		{
			
			if (Time.timeScale == 0) {

				Voltamos.SetActive (true);
				StartCoroutine (Espera());
			} else {
				
				//AudioSource.PlayClipAtPoint (Corta, transform.position);

				Voltamos.SetActive (false);
				hud01.SetActive (false);
				hud02.SetActive (false);
				hud03.SetActive (false);

				pausemenu.SetActive (true);
				Time.timeScale = 0;
				gameObject.GetComponent<Blink> ()._pause = true;
			}
				//SceneManager.LoadScene (4);
			Debug.Log("Pause");


		}
			
		if (aud < 0) {
			SceneManager.LoadScene (6);

		}
	}


	IEnumerator PerderPonto(){
		int j = 0;

		while (j == 0) {

			if (ChaosPorTempo) {

				if (x > 0) {
					x -= PontosPerdidosPorSegundo;
				} else if (y > 0) {
					y -= PontosPerdidosPorSegundo;
				} else if (z > 0) {
					z -= PontosPerdidosPorSegundo;
				}

			} else {
				
				if (x > 0) {
					x -= PontosPerdidosPorSegundo * ChaosMultiplier;
				} else if (y > 0) {
					y -= PontosPerdidosPorSegundo * ChaosMultiplier;
				} else if (z > 0) {
					z -= PontosPerdidosPorSegundo * ChaosMultiplier;
				}
			}

			yield return new WaitForSeconds (TempoEntrePontosPerdidos);
		}
	}

	IEnumerator AumentarChaos(){
		int j = 0;

		while (j == 0) {

			if (ChaosMultiplier < LimiteChaos) {
				ChaosMultiplier += ChaosIncrease;
			}
				
			if (ChaosPorTempo) {
				if (TempoEntrePontosPerdidos - ChaosMultiplier > 0) {
					TempoEntrePontosPerdidos -= ChaosMultiplier;
				}
			}

			yield return new WaitForSeconds (ChaosTimeIncrease);
		}
	}

	IEnumerator Dinheiro(){
		int j = 0;

		while (j == 0) {

			_money += 1 * aud;

			yield return new WaitForSeconds(0);
		}
	}
}
