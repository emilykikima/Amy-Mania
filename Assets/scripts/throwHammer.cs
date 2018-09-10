using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwHammer : MonoBehaviour {

	// button to fire rocket
	public KeyCode fireButton ;

	// the rocket prfab to instantiate (spawn)
	public GameObject rocketPrefab ;
	public GameObject rocketInstance ;

	public GameObject spawnpoint ;
	public gameManager gm ;

	public bool facingRight;
	//public bool hasHammer = true;


	// Use this for initialization
	void Start () {
		gm = gameManager.instance;
		if (gm.hasHammer < 1)
			gm.hasHammer = 1;
	}

	// Update is called once per frame
	void Update () {
		gm.currentX = this.transform.position.x ;
		gm.currentY = this.transform.position.y ;
		if (gm.hasHammer > 0) {
			if (Input.GetKeyDown (fireButton)) {
				facingRight = gameObject.GetComponent<playerMove> ().facingRight;
				if (facingRight) {
					//instantiate rocket going right
					rocketInstance = Instantiate (rocketPrefab, spawnpoint.transform.position, Quaternion.identity);
				} else {
					//instantiate rocket going left
					rocketInstance = Instantiate (rocketPrefab, spawnpoint.transform.position, Quaternion.Euler (0, 0, 180));
					rocketInstance.GetComponent<hammerMove> ().facingRight = facingRight;
				} // end if else
				gm.hasHammer -- ;
				gm.firstToss = this.transform.position.x ;
			} // end if GetKeyDown
		} // end if hasHammer
	} // end Update
}
