using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject board;

	public float WidthBoundMultiplier = 5.5f;
	public float HeightBoundMultiplier = 5.5f;
	public float DragVelocity = 10.0f;
	public float HoldMouseTime = 0.2f;

	public float zoomOut = 80.0f;
	public float zoomIn = 20.0f;


    private Vector3 _initialCameraPos;
	private float _cameraWidth;
	private float _cameraHeight;
	private Vector3 _boardBounds;

	public bool _InZoom = false;
    public bool _Zoom = false;

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
		//_boardBounds = board.transform.GetComponent<Bounds>().size.x;

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

				if (mouseX < board.GetComponent<Collider> ().bounds.size.x / 2 &&
					mouseX > -board.GetComponent<Collider> ().bounds.size.x / 2 &&
					mouseY < board.GetComponent<Collider> ().bounds.size.z / 2 &&
					mouseY > -board.GetComponent<Collider> ().bounds.size.z / 2) {

					Camera.main.transform.position = (new Vector3 (mouseX, 100, mouseY) + Camera.main.transform.position)/2.0f;

                    _Zoom = true;
                }



                //float fov = Mathf.Clamp(5f + 27f, 27f, 5f);
                //Camera.main.fieldOfView = fov;

                //Faz o zoom gradual da câmera
                if (_Zoom)
                {
                    if (Camera.main.orthographicSize - zoomIn > 1)
                    {
                        Camera.main.orthographicSize = (Camera.main.orthographicSize + zoomIn) / 2.0f;
                    }
                    else
                    {
                        Camera.main.orthographicSize = zoomIn;

                        _Zoom = false;
                   } 
                }


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
				//Camera.main.orthographicSize = zoomOut;
				//transform.position = _initialCameraPos;

				_InZoom = false;
                _Zoom = true;
			}
            

			clickTimer = 0.0f;

		}

        if (!_InZoom && _Zoom)
        {
            if (zoomOut - Camera.main.orthographicSize > 1)
            {
                transform.position = (_initialCameraPos + transform.position) / 2.0f ;
                Camera.main.orthographicSize = (Camera.main.orthographicSize + zoomOut) / 2.0f;
            }
            else
            {
                Camera.main.orthographicSize = zoomOut;

                _Zoom = false;
            }
        }
    }

}
