using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSounds : MonoBehaviour {

	AudioSource ring ;

	void Start() {
		ring = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("spring")) {
			ring.Play ();
		}
	}
}
