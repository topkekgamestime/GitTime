using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToStart : MonoBehaviour {

	public AudioSource audio;

	public void Play()
	{
		SceneManager.LoadScene (1);
	}

	public void Audio()
	{
		audio.Play();
	}

}
