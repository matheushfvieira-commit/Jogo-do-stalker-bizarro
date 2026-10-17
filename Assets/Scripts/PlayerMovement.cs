using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[Header("player Controle/Camera")]
	public Camera playerCam;

	public CharacterController controller;
	public float velocidade = 5f;
	public float gravidade = -9.81f;

	public int ZoomFOV = 35;
	public int initialFOV;
	public float cameraZoomSmooth = 1;

	private bool isZoomed = false;

	Vector3 velocidadeVertical;

	[Header("Player Sounds")]
	public AudioSource cameraZoomSound;

	public AudioSource somPassosSource;
	public AudioClip somDePassos;

	

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 mover = transform.right * x + transform.forward * z;
		controller.Move(mover * velocidade * Time.deltaTime);
		if ( controller.isGrounded && velocidadeVertical.y < 0){
			velocidadeVertical.y = -2f;
		}
		velocidadeVertical.y += gravidade * Time.deltaTime;
		controller.Move(velocidadeVertical * Time.deltaTime);

		if(Input.GetButtonDown("Fire2"))
        {
            isZoomed = true;
            cameraZoomSound.Play();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            isZoomed = false;
            cameraZoomSound.Play();
        }

        if (isZoomed)
        {
            playerCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(playerCam.fieldOfView, ZoomFOV, Time.deltaTime * cameraZoomSmooth);
        }

        else if (!isZoomed)
        {
            playerCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(playerCam.fieldOfView, initialFOV, Time.deltaTime * cameraZoomSmooth);
        }

		if (controller.isGrounded && (x != 0 || z != 0))
		{
			if (!somPassosSource.isPlaying)
			{
				somPassosSource.clip = somDePassos;
				somPassosSource.loop = true;
				somPassosSource.Play();
			}
		}
		else 
		{
			if (somPassosSource.isPlaying)
			{
				somPassosSource.Stop();
			}
		
		}
	}
}