using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerMove : MonoBehaviour {

	public float hSpeed = 1.5f ;

	public float maxDistance = 3f ;
	public float startPoint = 0f ;
	public float returnPoint ;
	public bool added = false;

	Rigidbody2D rb ;
	AudioSource kill ;
	public GameObject startPos ;
	public throwHammer thrower ;
	public gameManager gm ;
	public bool directionOnThrow;

	public bool facingRight = true;
	public GameObject player ;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		kill = gameObject.GetComponent<AudioSource> ();
		thrower = gameObject.GetComponent<throwHammer> ();
		gm = gameManager.instance;

		if (facingRight) {
			directionOnThrow = true;
			rb.velocity = new Vector2 (hSpeed, 0);
		} else {
			directionOnThrow = false;
			rb.velocity = new Vector2 (-hSpeed, 0);
		}

	}

	void Update() {
		//if (gm.hasHammer == false) {
			float currentDistance = calcDistance ();
			if (currentDistance > maxDistance) {
				print ("Whoah nelly");
				if (directionOnThrow) {
					rb.velocity = new Vector2 (-hSpeed, 0);
				} else {
					rb.velocity = new Vector2 (hSpeed, 0);
				}
			} else {
				print (currentDistance);
			}
		//}
	}

	//check object it collides with, and destroys objects with tags labeled "destructible" and the rocket itself
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("enemy")) {
			Destroy (coll.gameObject); //destroys the object with collider tagged "destructible"
			print("360 no scope") ;
			gm.enemies--;
			kill.Play() ;
		} else if (coll.CompareTag ("Player")) {
			Destroy(gameObject) ;
			if (added == false) {
				gm.hasHammer++;
				added = true;
			}
		}
	} // end onTriggerEnter2D

	float calcDistance() {
		float x = gm.firstToss ;
		return Mathf.Sqrt ((this.transform.position.x - x)*(this.transform.position.x - x));
	}
}

