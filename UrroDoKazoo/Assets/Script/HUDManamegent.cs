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
	public int money = 0;
	public Text kazoos;
	[Range(0,100)]
	public int caos;
	[Range(0,100)]
	public int aud;

	public Slider Fofo;
	public Slider Humor;
	public Slider Treta;
	public Slider Aud;
	public Animator AudAnim;

	public float PontosPerdidosPorSegundo = 1.0f;
	public float TempoEntrePontosPerdidos = 1.0f;

	// Use this for initialization
	void Start () {

		x = 30.0f;
		y = 30.0f;
		z = 30.0f;

		StartCoroutine (PerderPonto ());

	}
	
	// Update is called once per frame
	void Update () {
		Fofo.value = x;
		Humor.value = y;
		Treta.value = z;
		Aud.value = aud;
		AudAnim.SetFloat("value", Aud.value);
		kazoos.text = money.ToString();

		if(Input.GetKeyDown("escape") || Input.GetKeyDown("space"))
		{
			SceneManager.LoadScene (3);
				Debug.Log("Pause");
		}

		if (x == 0 || y == 0 || z == 0) {
			Debug.Log ("Perdeu lixo");
		}
	}


	IEnumerator PerderPonto(){
		int j = 0;

		while (j == 0) {
			
			x -= PontosPerdidosPorSegundo;
			y -= PontosPerdidosPorSegundo;
			z -= PontosPerdidosPorSegundo;

			yield return new WaitForSeconds (TempoEntrePontosPerdidos);
		}
	}
}
