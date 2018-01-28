using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {

	public Animator personAnim;

	void Update()
	{
		if (this.GetComponent<Renderer>().IsVisibleFrom (Camera.main)) {

			Debug.Log (gameObject.name + " AAAAA");

			if (Camera.main.GetComponent<CameraController> ()._InZoom) {

				Debug.Log ("Voce consegue me ver " + gameObject.name);

				if (personAnim.GetCurrentAnimatorStateInfo(0).IsName("fofo")) {
					Debug.Log ("Fofo");
				} else if (personAnim.GetCurrentAnimatorStateInfo(0).IsName("tragedia")) {
					Debug.Log ("Tragedia");
				} else if (personAnim.GetCurrentAnimatorStateInfo(0).IsName("humor")) {
					Debug.Log ("Humor");
				}

			}

		} else {

			Debug.Log (this.name + " Nome do rejeitado");

			Debug.Log ("Not visible");
		}
	}
}
