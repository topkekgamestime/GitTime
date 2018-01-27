using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject board;

	public float WidthBoundMultiplier = 5.5f;
	public float HeightBoundMultiplier = 5.5f;
	public float DragVelocity = 10.0f;


	private Vector3 _initialCameraPos;
	private float _cameraWidth;
	private float _cameraHeight;
	private Vector3 _boardBounds;

	private bool _InZoom = false;

	float minFov = 15f;
	float maxFov = 90f;
	float sensitivity = 10f;



	float clickTimer;

	bool imBeingDragged = false;


	// Use this for initialization
	void Start () {
		_initialCameraPos = gameObject.transform.position;
		_cameraWidth = gameObject.GetComponent<Camera> ().rect.width;
		_cameraHeight = gameObject.GetComponent<Camera> ().rect.height;

		_boardBounds = board.transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {

			clickTimer += Time.deltaTime;

			if (clickTimer >= .3f) {

				if (_InZoom) {

					Vector3 position = gameObject.transform.position;

					if (Input.GetAxis ("Mouse X") > 0) {
						if (position.x <= _boardBounds.x + WidthBoundMultiplier * _cameraWidth && position.y <= _boardBounds.y + HeightBoundMultiplier * _cameraHeight) {
							transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * DragVelocity, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * DragVelocity);
						}
					} else if (Input.GetAxis ("Mouse X") < 0) {
						if (position.x >= -_boardBounds.x - WidthBoundMultiplier * _cameraWidth && position.y >= -_boardBounds.y - HeightBoundMultiplier * _cameraHeight) {
							transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * DragVelocity, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * DragVelocity);
						}
					}
				}
			}
		}


		if (Input.GetMouseButtonUp (0)) {

			if (clickTimer <= .3f) {

				if (_InZoom) {
					float fov = Mathf.Clamp (5f + 27f, 5f, 27f);
					Camera.main.fieldOfView = fov;

					_InZoom = false;
				} else {
					float fov = Mathf.Clamp(5f + 27f, 27f, 5f);
					Camera.main.fieldOfView = fov;

					_InZoom = true;
				}
			} 

			clickTimer = 0.0f;

		}


		/*f (_InZoom) {
			Vector3 position = gameObject.transform.position;

			Debug.Log (EventType.MouseDrag + " DRAG");
			if (Input.GetAxis ("Mouse X") > 0) {
				if (position.x <= _boardBounds.x + 5.5 * _cameraWidth && position.y <= _boardBounds.y + 5.5 * _cameraHeight) {
					transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * _speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * _speed);
				}
			} else if (Input.GetAxis ("Mouse X") < 0) {
				if (position.x >= -_boardBounds.x - 5.5 * _cameraWidth && position.y >= -_boardBounds.y - 5.5 * _cameraHeight) {
					transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * _speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * _speed);
				}
			}

		}*/

		//if (Input.GetMouseButtonDown (0)) {

			//if (_InZoom) {
				//Vector3 position = gameObject.transform.position;
				//if (Input.GetAxis ("Mouse X") > 0) {
				/*if (position.x <= _boardBounds.x + 5.5 * _cameraWidth && position.y <= _boardBounds.y + 5.5 * _cameraHeight) {
					transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * _speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * _speed);
				}*/
				//} else if (Input.GetAxis ("Mouse X") < 0) {
				/*if (position.x >= -_boardBounds.x - 5.5 * _cameraWidth && position.y >= -_boardBounds.y - 5.5 * _cameraHeight) {
					transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * _speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * _speed);
				}*/
				//}

				/*if (!imBeingDragged) {
					float fov = Mathf.Clamp(5f + 27f, 5f, 27f);
					Camera.main.fieldOfView = fov;

					_InZoom = false;

				}*/


				/*if (Input.GetAxis ("Mouse X") == 0) {
					
					float fov = Mathf.Clamp(5f + 27f, 27f, 5f);
					Camera.main.fieldOfView = fov;

					_InZoom = false;
				}*/

			/*} else {

				//var fov: float = Camera.main.fieldOfView;
				//fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
				float fov = Mathf.Clamp(5f + 27f, 27f, 5f);
				Camera.main.fieldOfView = fov;

				_InZoom = true;
			}*/

		//}



		/*if (Input.GetMouseButton(0)) {
			Camera mycam = GetComponent<Camera>();
			transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);

			//transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			/*Vector3 mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
		}*/

		/*if (BoardBounds () == true) {
			moveCamera ();
		}*/
	
	}

	/*void OnMouseDrag() {

		Debug.Log ("DRAG");
	
		if (_InZoom) {

			Vector3 position = gameObject.transform.position;

			if (Input.GetAxis ("Mouse X") > 0) {
				if (position.x <= _boardBounds.x + 5.5 * _cameraWidth && position.y <= _boardBounds.y + 5.5 * _cameraHeight) {
					transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * _speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * _speed);
				}
			} else if (Input.GetAxis ("Mouse X") < 0) {
				if (position.x >= -_boardBounds.x - 5.5 * _cameraWidth && position.y >= -_boardBounds.y - 5.5 * _cameraHeight) {
					transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * _speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * _speed);
				}
			}
		}
		
		//if (!imBeingDragged) {
			imBeingDragged = true;
		//}
	}
	
	void OnMouseUp(){
		imBeingDragged = false;
	}*/

	bool BoardBounds() {
		Vector3 position = gameObject.transform.position;

	if (position.x <= (_boardBounds.x + _cameraWidth/2)) {
			Debug.Log ("entrou1");
			return true;
		/*if (position.y < (_boardBounds.y + _cameraHeight/2)) {
			Debug.Log ("entrou2");

				return true;
			}*/
		}

		return false;
	}

	void moveCamera() {
		Camera mycam = GetComponent<Camera>();
		transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);


		/*Camera cam = GetComponent<Camera>();

		float sensitivity = 0.05f;
		Vector3 vp = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
		vp.x -= 0.5f;
		vp.y -= 0.5f;
		vp.x *= sensitivity;
		vp.y *= sensitivity;
		vp.x += 0.5f;
		vp.y += 0.5f;
		Vector3 sp = cam.ViewportToScreenPoint(vp);

		Vector3 v = cam.ScreenToWorldPoint(sp);
		transform.LookAt(v, Vector3.up);*/
	}

}
