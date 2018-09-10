using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {

	public changeScene changer ;

	// Use this for initialization
	void Start () {
		changer = GameObject.Find("sceneManager").GetComponent<changeScene>() ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("enemy")) {
			print ("death awaits");
			changer.sceneChange (3);
		} else if (col.CompareTag ("Player")) {
			changer.sceneChange (21);
		}

	}
}
