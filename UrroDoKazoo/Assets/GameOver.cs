using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Slider Countdown;

	private float gameover;


	void Start () {
		gameover = Countdown.value;
	}

	void Update () {
		/*if (gameover != 0) 
		{
			gameover = Countdown.value;
		} 

		else */
		Debug.Log (gameover);
	}
}
