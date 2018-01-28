using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void Back()
	{
		SceneManager.LoadScene (0);
	}

	public void Play()
	{
		SceneManager.LoadScene (1);
	}

	public void Credits()
	{
		SceneManager.LoadScene (2);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
