using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyMove : MonoBehaviour {

	// MAGD 272 - Fall 2017

	//	This script is meant to show examples of different types of movement capabilities. 
	//	Some use position change, some involve physics, some use some interpolation, but all rely in built-in functions/methods.

	//  This script uses POSITION CHANGE, which addresses the GameObject's Transform. Note that the transform has three dimensions, regardless if it's 3D or 2D.

	//	Need an object on the scene as an example object
	public GameObject object2Move;

	// Set the units per frame to move.
	public float movementSpeed;

	public float leftX, rightX, topY, bottomY ;

	// an int that keeps track of which direction the object should move
	// 1 = left
	// 2 = right
	// 3 = up
	// 4 = down
	public int direction ;


	// Use this for initialization
	void Start () {
		// This is just a check to make sure a reference to a GameObject has been make, if you haven't associated it with an GameObject, it will link it to the
		// Object this script is attached to. 
		if (object2Move == null) {
			object2Move = gameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		move();
	}

	// this function just uses Position (from the Tranform), adding the 'movementSpeed' in the X dimension
	void move(){


		switch (direction) {
		case 1: // for left
			object2Move.transform.position += new Vector3 (-movementSpeed, 0f, 0f);
			if (leftX > gameObject.transform.position.x) {
				print ("It has passed");
				direction = 2;
				flip ();
			}
			break ;

		case 2: // for right
			object2Move.transform.position += new Vector3 (movementSpeed, 0f, 0f);
			if (rightX < gameObject.transform.position.x){
				direction = 1 ;
				flip ();
			}
			break ;
		case 3: // for up
			object2Move.transform.position += new Vector3 (0f, movementSpeed, 0f);
			if (topY < gameObject.transform.position.y)
				direction = 4 ;
			break ;
		case 4: // for down
			object2Move.transform.position += new Vector3 (0f, -movementSpeed, 0f);
			if (bottomY > gameObject.transform.position.y)
				direction = 3 ;
			break ;

		}
	}
	void flip(){
		// grab the current state of the transform.localscale, assign it to temporary variable named 'theScale'
		Vector3 theScale = transform.localScale; 
		// take the x-value from theScale and multiply it by -1 and assign it back to it the variable(inverse identity of multplication: value * -1 = -value)
		theScale.x *= -1;   // this shorthand for 'theScale.x = theScale.x * -1'
		// assign theScale (the x-value inverted) back to the character's localscale. 
		transform.localScale = theScale;
	}
}
