using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toRace : MonoBehaviour {

	public gameManager gm ;
	public GameObject object2Move;
	public float movementSpeed;

	public float bottomY ;

	// Use this for initialization
	void Start () {
		gm = gameManager.instance;

		if (object2Move == null) {
			object2Move = gameObject;
		}
		if (gm.enemies < 9)
			gm.enemies = 9;
	}

	// Update is called once per frame
	void Update () {
		if (gm.enemies < 1) {
			object2Move.transform.position += new Vector3 (0f, movementSpeed, 0f);
			if (bottomY > gameObject.transform.position.y) {
				object2Move.transform.position += new Vector3 (0f, -movementSpeed, 0f);
				object2Move.transform.position += new Vector3 (0f, 0f, 0f);
			}
		}
	}
}
