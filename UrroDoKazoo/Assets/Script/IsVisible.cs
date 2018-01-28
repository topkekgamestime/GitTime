using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {


	void Update()
	{
		if (GetComponent<Renderer> ().IsVisibleFrom (Camera.main)) {
			
			if (gameObject.GetComponent<Animation> ().IsPlaying ("evento_fofo2")) {
				Debug.Log ("Fofo");
			} else if (gameObject.GetComponent<Animation> ().IsPlaying("evento_tragedia1")) {
				Debug.Log ("Tragedia");
			} else if (gameObject.GetComponent<Animation> ().IsPlaying ("evento_humor1")) {
				Debug.Log ("Humor");
			}


		} else {
			Debug.Log ("Not visible");
		}
	}
}
