using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUTE : MonoBehaviour {

	public bool IsMuted;
	public GameObject vol;

	// Use this for initialization
	void Awake () {

	}

	void Start () {
		if (IsMuted == true) 
		{
			vol.GetComponent<AudioListener> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
