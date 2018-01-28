using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {

	public Animator personAnim;

	void Update()
	{
		if (GetComponent<Renderer> ().IsVisibleFrom (Camera.main)) {
			//fofo,humor,tragedia
			
			if (personAnim.GetCurrentAnimatorStateInfo(0).IsName("fofo")) {
				Debug.Log ("Fofo");
			} else if (personAnim.GetCurrentAnimatorStateInfo(0).IsName("tragedia")) {
				Debug.Log ("Tragedia");
			} else if (personAnim.GetCurrentAnimatorStateInfo(0).IsName("humor")) {
				Debug.Log ("Humor");
			}

		} else {
			Debug.Log ("Not visible");
		}
	}
}
