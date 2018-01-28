using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject board;

	public float WidthBoundMultiplier = 5.5f;
	public float HeightBoundMultiplier = 5.5f;
	public float DragVelocity = 10.0f;
	public float HoldMouseTime = 1.0f;

	public float zoomOut = 80.0f;
	public float zoomIn = 20.0f;


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

			if (clickTimer >= HoldMouseTime) {

				float mouseGamePositionX = board.GetComponent<Collider> ().bounds.size.x * Input.mousePosition.x / Screen.width;
				float mouseGamePositionY = board.GetComponent<Collider> ().bounds.size.z * Input.mousePosition.y / Screen.height;

				float mouseX = board.GetComponent<Collider> ().bounds.size.x / 2 - mouseGamePositionX;
				float mouseY = board.GetComponent<Collider> ().bounds.size.z / 2 - mouseGamePositionY;

				Camera.main.transform.position = new Vector3 (mouseX, 100, mouseY);

				//float fov = Mathf.Clamp(5f + 27f, 27f, 5f);
				//Camera.main.fieldOfView = fov;
				Camera.main.orthographicSize = zoomOut;

				_InZoom = true;

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


			if (_InZoom) {
				//float fov = Mathf.Clamp (5f + 27f, 5f, 27f);
				//Camera.main.fieldOfView = fov;
				Camera.main.orthographicSize = zoomIn;
				transform.position = _initialCameraPos;

				_InZoom = false;
			}

			clickTimer = 0.0f;

		}
	
	}

}
