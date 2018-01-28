using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

	void Start () {

	}

	void Update () {
		if(Input.GetKeyDown("space"))
			{
				SceneManager.LoadScene (0);
			}
	}
}
