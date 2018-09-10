using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialPlatform : MonoBehaviour {
	float vVal;
	public float vSpeed; // the max horizontal speed of char. change in inspector
	public float jumpVal;
	public bool onGround = false;
	public bool firing = false ;
	public int max = 0 ;

	Rigidbody2D rb;    // rigidbody ref
	AudioSource jump ;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		jump = gameObject.GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		moveChar ();
	}

	void moveChar(){
		if (firing) {
			float vVelocity = vVal * jumpVal;
			rb.velocity = new Vector2 (0, vVelocity);
			vVal = 1; 
			max++;
			if (max > 30) {
				max = 0;
				firing = false ;
			}
		} else {
			vVal = 0;
		}
	}

	// use OnTriggerEnter2D check
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag("ground") || coll.CompareTag("platform")){
			onGround = true;
		} else if (coll.CompareTag("Player")) {
			print ("Fire the lazers!");
			jump.Play ();
			firing = true ;
		} // end if else
	} // end OnTriggerEnter2D

	//ensures character stays on the ground if he transitions from one ground object to another
	void OnTriggerStay2D(Collider2D coll){
		if (coll.CompareTag("ground") || coll.CompareTag("platform")){
			onGround = true;
		} // end if
	} // end OnTriggerStay2D

	//if character leaves object tagged "Ground", state changes
	void OnTriggerExit2D(Collider2D coll){
		if (coll.CompareTag("ground") || coll.CompareTag("platform")){
			onGround = false;
			firing = false;
		} // end if
		if (coll.CompareTag("Player")){
			firing = false;
		} // end if
	} // end OnTriggerExit2D

}
