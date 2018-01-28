using System.Collections;
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

	// Use this for initialization
	void Start () {

		Fofo.value = 35.0f;
		Humor.value = 35.0f;
		Treta.value = 35.0f;

		StartCoroutine (PerderPonto ());
		StartCoroutine (AumentarChaos ());

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

		if (x == 0 || y == 0 || z == 0) {
			Debug.Log ("Perdeu lixo");
		}

		if (aud < 0) {
			SceneManager.LoadScene (6);

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
				if (TempoEntrePontosPerdidos - ChaosMultiplier > 0) {
					TempoEntrePontosPerdidos -= ChaosMultiplier;
				}
			}

			yield return new WaitForSeconds (ChaosTimeIncrease);
		}
	}
}
