using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject vol;

	private bool IsMuted = false;


	/*void Awake()
	{
		DontDestroyOnLoad(this);



		if (FindObjectsOfType(GetType()).Length > 1)
		{
			if (vol == null) {
				Destroy (vol);
			}
		}
	}*/





	public void Back()
	{
		SceneManager.LoadScene (0);
		//Destroy (vol);
	}

	public void Play()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("StartSong");
		if (objs.Length <= 1) {
			SceneManager.LoadScene (1);
		}
	}

	public void Credits()
	{
		DontDestroyOnLoad (vol.GetComponent<AudioSource>());
		SceneManager.LoadScene (2);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void Mute()
	{
		if (IsMuted == false) {
			vol.GetComponent<AudioSource> ().enabled = false;
			IsMuted = true;
		} 
		else 
		{
			vol.GetComponent<AudioSource> ().enabled = true;
			IsMuted = false;
		}

	}
}
