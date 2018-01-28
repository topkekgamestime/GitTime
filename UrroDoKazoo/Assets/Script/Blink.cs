using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {

	public GameObject blinkable;
	public float time;

	void Start () {
		StartCoroutine (BlinkObj ());
	}


	IEnumerator BlinkObj()
	{
		while(true)
		{
		yield return new WaitForSecondsRealtime(time);
		blinkable.SetActive (false);
		yield return new WaitForSecondsRealtime(time);
		blinkable.SetActive (true);
		}
	}

}
