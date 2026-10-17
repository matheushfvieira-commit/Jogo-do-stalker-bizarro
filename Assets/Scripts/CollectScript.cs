using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour {

	public GameObject collectText;

	public AudioSource collectSound;

	private GameObject item;

	private bool inReach;

	public GameObject gameLogic;

	// Use this for initialization
	void Start () {
		collectText.SetActive(false);

		inReach = false;

		gameLogic = GameObject.FindWithTag("GameLogic");

		item = this.gameObject;	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Reach"){
			inReach = true;
			collectText.SetActive(true);
		}
	}
	void OnTriggerExit(Collider other){
		
		if (other.gameObject.tag == "Reach"){
			inReach = false;
			collectText.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		
		if (inReach && Input.GetKey(KeyCode.E)){

			gameLogic.GetComponent<GameLogic>().VHSCount += 1;

			collectSound.Play();
			collectText.SetActive(false);
			item.SetActive(false);
			inReach = false;
		}
	}
}
