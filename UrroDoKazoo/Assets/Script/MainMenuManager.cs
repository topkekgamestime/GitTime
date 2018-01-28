using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject vol;

	private bool IsMuted;

	void Start ()
	{
		if (IsMuted == true) 
		{
			vol.GetComponent<AudioListener> ().enabled = false;
		}
		else 	vol.GetComponent<AudioListener> ().enabled = true;

	}

	public void Back()
		{
			SceneManager.LoadScene (0);
	
		}

	public void Play()
		{
			SceneManager.LoadScene (4);
		}

	public void Credits()
		{
			SceneManager.LoadScene (2);
		}

	public void Quit()
		{
			Application.Quit ();
		}

	public void Mute()
	{
		if (IsMuted == false) {
			vol.GetComponent<AudioListener> ().enabled = false;
			IsMuted = true;
		} 
		else 
		{
			vol.GetComponent<AudioListener> ().enabled = true;
			IsMuted = false;
		}

	}
}
