using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {

	public GameObject blinkable;
	public float time;

	public bool _pause = false;

	void Start () {
		StartCoroutine (BlinkObj ());
	}


	IEnumerator BlinkObj()
	{
		while(true)
		{
			yield return new WaitForSecondsRealtime(time);
			if (_pause == false) {
				blinkable.SetActive (false);
			}
			yield return new WaitForSecondsRealtime(time);
			if (_pause == false) {
				blinkable.SetActive (true);
			}
		}
	}

}
