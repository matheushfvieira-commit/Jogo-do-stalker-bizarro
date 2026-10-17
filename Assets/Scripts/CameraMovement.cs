using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float sensibilidade = 200f;
	bool cameraAtiva = false;
	float rotacaoX = 0f;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0)){
			cameraAtiva = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			cameraAtiva = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (!cameraAtiva){
			return;
		}
		float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;

		float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;

		

		rotacaoX -= mouseY;

		rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

		transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);

		transform.parent.Rotate(Vector3.up * mouseX);
	}
}