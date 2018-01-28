using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour {

	public AudioClip resume;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
		{
			AudioSource.PlayClipAtPoint (resume, transform.position);
			StartCoroutine (Voltando ());

		}
	}

	IEnumerator Voltando()
	{
		yield return new WaitForSecondsRealtime(3.15f);
		SceneManager.LoadScene (1);
		Debug.Log("Resume");
	}

}
