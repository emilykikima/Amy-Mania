using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringCollector : MonoBehaviour {

	public gameManager gm ;
	public AudioSource sound ;
	public bool wasUsed = false ;
	public Animator anim ;
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
				gm.rings++;
				wasUsed = true;
				anim.SetBool ("got", true);
			}
		}
	}
}
