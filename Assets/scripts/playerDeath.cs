using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour {

	Animator anim ;
	public changeScene changer ;
	public AudioSource spring ;
	public AudioSource hit ;
	public gameManager gm ;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		changer = GameObject.Find("sceneManager").GetComponent<changeScene>() ;
		AudioSource[] sounds = GetComponents <AudioSource>();

		spring = sounds[0] ;
		hit = sounds[1] ;

		gm = gameManager.instance;
	}

	// Update is called once per frame
	void Update () {

	}

	// when character collides with this key object...
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("death")) {
			print ("You Died");
			// play death animation
			anim.SetBool ("isDead", true);

			// change to gameOver scene
			changer.sceneChange (4);
		} else if (col.CompareTag ("enemy")) {
			if (gm.rings > 0) {
				gm.rings = 0;
				hit.Play ();
			} else {
				changer.sceneChange (4);
			}
		} else if (col.CompareTag("changeScene")) {
			// change to the transit screen for the second stage
			changer.sceneChange(2) ;
		} else if (col.CompareTag("win")) {
			// change to the end scene where you win
			changer.sceneChange(4) ;
		} else if (col.CompareTag("lvltwo")) {
			// change to the end scene where you win
			changer.sceneChange(3) ;
		} else if (col.CompareTag("spring")) {
			// change to the end scene where you win

		}
	}
}
