using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

	public Text pontuacao;

	public HUDManamegent mgn;

	void Start () {
		pontuacao.text = "0";
		pontuacao.text = mgn.money.ToString();


	}

	void Update () {
		if(Input.GetKeyDown("space"))
			{
				SceneManager.LoadScene (1);
			}
	}
}
