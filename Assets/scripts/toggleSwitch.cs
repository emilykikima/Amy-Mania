using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSwitch : MonoBehaviour {

// reference the gameManager
public gameManager gm ;
public Animator anim ;
public AudioSource sound ;

public bool wasUsed = false ;

// Use this for initialization
void Start () {
	gm = gameManager.instance;
	anim = gameObject.GetComponent<Animator> ();
	sound = gameObject.GetComponent<AudioSource> ();
}

void OnTriggerEnter2D(Collider2D coll){
	if (coll.CompareTag ("Player")) {
		//Destroy(gameObject) ;
		if (wasUsed == false) {
			sound.Play() ;
			anim.SetBool ("on", true);
			gm.switches++;
			wasUsed = true;
		}
	}
} // end onTriggerEnter2D
}
