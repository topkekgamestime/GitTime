using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {


	void Update()
	{
		if (GetComponent<Renderer>().IsVisibleFrom(Camera.main)) 
			Debug.Log("Hahaha");
		else Debug.Log("Not visible");
	}
}
