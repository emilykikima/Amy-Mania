using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	float hVal;
	float vVal;
	bool jumpPressed;
	public int jumpCount = 0;
	public int jumpLimit = 2;

	public float maxVerticalVelocity = 2f;

	public float hSpeed; // the max horizontal speed of char. change in inspector
	public float jumpVal;

	Rigidbody2D rb;    // rigidbody ref
	Animator anim;
	AudioSource jump ;
	public gameManager gm ;


	public bool facingRight = true; //if your sprite is naturally to the right, set this var "true", if sprite naturally faces left, set "false"

	public bool onGround = false;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();// finds the rigidbody component of the character (if this script is also on the character)
		anim = gameObject.GetComponent<Animator> ();
		jump = gameObject.GetComponent<AudioSource> ();
		gm = gameManager.instance;

		gm.rings = 0;
		gm.enemies = 9;
	}

	// Update is called once per frame
	void Update () {
		getInput();
	}

	void FixedUpdate(){
		moveChar ();
	}

	void getInput(){
		hVal = Input.GetAxisRaw ("Horizontal");
		if (Input.GetKeyDown (KeyCode.Space)) {
			jumpPressed = true;
		} else
			jumpPressed = false;
	}

	void moveChar(){
		float hVelocity = hVal * hSpeed;
		float vVelocity = vVal * jumpVal;

		float clampedVertical = Mathf.Clamp (rb.velocity.y + vVelocity, -100f, maxVerticalVelocity);
		rb.velocity = new Vector2 (hVelocity, clampedVertical);
		//freezes vertical velocity before jumping to get a consistent jump
		if (jumpPressed) {
			if ((jumpCount < jumpLimit) || (onGround)) {
				jump.Play ();
				rb.velocity = new Vector2 (rb.velocity.x, 0f);
				vVal = 1;
				jumpPressed = false;
				jumpCount++;
			}
		} else {
			vVal = 0;
		}
		//sends absolute value of hVelocity to Animator parameter "hSpeed"
		anim.SetFloat("hSpeed", Mathf.Abs (hVelocity));

		//sends the rigidbody's vertical velocity to Animator parameter "vSpeed"
		anim.SetFloat ("vSpeed", rb.velocity.y);

		anim.SetBool ("onGround", onGround);

		//this 'if statement checks' for a condition to call the flip function (line 74)
		// "if character isn't facing to the right, when we press the move right button, flip the character so it is facing right."
		// OR
		// "if character isn't facing to the left, when we press the move left button, flip the character so it is facing left"
		if ((!facingRight && hVal > 0)||(facingRight && hVal < 0))  {
			flip ();
		} 
	}
	//this function flips (reverses) the x-value on scale parameter of your character's transform.
	void flip(){
		// grab the current state of the transform.localscale, assign it to temporary variable named 'theScale'
		Vector3 theScale = transform.localScale; 
		// take the x-value from theScale and multiply it by -1 and assign it back to it the variable(inverse identity of multplication: value * -1 = -value)
		theScale.x *= -1;   // this shorthand for 'theScale.x = theScale.x * -1'
		// assign theScale (the x-value inverted) back to the character's localscale. 
		transform.localScale = theScale;
		// make sure to change the boolean 'facingRight'
		facingRight = !facingRight;     // this is an amazing shorthand that turns booleans the opposite of their binary state (true if false; false if true)
	}

	// use OnTriggerEnter2D check
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag("ground") || coll.CompareTag("platform")){
			onGround = true;
			jumpCount = 0;
		}
	}

	//ensures character stays on the ground if he transitions from one ground object to another
	void OnTriggerStay2D(Collider2D coll){
		if (coll.CompareTag("ground") || coll.CompareTag("platform")){
			onGround = true;
		}

		if (coll.CompareTag ("platform")) {
			transform.parent = coll.transform;
		}
	}

	//if character leaves object tagged "Ground", state changes
	void OnTriggerExit2D(Collider2D coll){
		if (coll.CompareTag("ground") || coll.CompareTag("platform")){
			onGround = false;
		}

		if (coll.CompareTag ("platform")) {
			transform.parent = GameObject.Find("characters").transform;
		}

	}
} 
