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


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Fofo.value = x;
		Humor.value = y;
		Treta.value = z;
		Aud.value = aud;
		kazoos.text = money.ToString();

		if(Input.GetKeyDown("escape") || Input.GetKeyDown("space"))
		{
			SceneManager.LoadScene (3);
				Debug.Log("Pause");
		}
	}
}
