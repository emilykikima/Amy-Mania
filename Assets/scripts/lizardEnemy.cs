using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizardEnemy : MonoBehaviour {

	// the rocket prfab to instantiate (spawn)
	public GameObject rocketPrefab ;
	public GameObject rocketInstance ;
	public Animator anim ;
	public bool shot = false;

	public GameObject spawnpoint ;
	public bool facingRight;

	void Start() {
		anim = anim = gameObject.GetComponent<Animator> () ;
	} // end start

	void Update () {
		facingRight = gameObject.GetComponent<lizardEnemy> ().facingRight;
				
	
	} // end Update

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("Player")) {
			anim.SetBool ("inRange", true);
			shoot ();
			shot = true;
		} 
	} // end onTriggerEnter2D

	void shoot() {
		if (!shot) {
			if (!facingRight) {
				//instantiate rocket going right
				rocketInstance = Instantiate (rocketPrefab, spawnpoint.transform.position, Quaternion.identity);
			} else {
				//instantiate rocket going left
				rocketInstance = Instantiate (rocketPrefab, spawnpoint.transform.position, Quaternion.Euler (0, 0, 180));
				rocketInstance.GetComponent<rocketMove> ().facingRight = facingRight;
			} // end if else
		}
	}
}
