using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springSound : MonoBehaviour {


	AudioSource boing ;
	// Use this for initialization
	void Start () {
		boing = gameObject.GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			print ("Lift off");
			boing.Play() ;
		}
	}
}
