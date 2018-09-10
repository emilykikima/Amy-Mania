using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketMove : MonoBehaviour {

	public float hSpeed = 1.5f ;

	public float maxDistance = 3f ;
	public float startPoint = 0f ;
	public float returnPoint ;
	public bool added = false;

	Rigidbody2D rb ;
	public GameObject startPos ;
	public lizardEnemy thrower ;
	public bool directionOnThrow;

	public bool facingRight = false;
	public GameObject lizard ;

	// Use this for initialization
	void Start () {
		print ("Rocket has fired");
		rb = gameObject.GetComponent<Rigidbody2D> ();
		thrower = gameObject.GetComponent<lizardEnemy> ();

		if (!facingRight) {
			directionOnThrow = true;
			rb.velocity = new Vector2 (hSpeed, 0);
		} else {
			directionOnThrow = false;
			rb.velocity = new Vector2 (-hSpeed, 0);
		}

	}

	void Update() {
			if (directionOnThrow) {
				rb.velocity = new Vector2 (-hSpeed, 0);
			} else {
				rb.velocity = new Vector2 (hSpeed, 0);
			}
	}

	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.CompareTag ("Player")) {
			Destroy(gameObject) ;
		}
	} // end onTriggerEnter2D
}
