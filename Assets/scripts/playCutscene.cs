using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playCutscene : MonoBehaviour {

	public int cutsceneNo ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// when character collides with this key object...
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			// play cutscene
			SceneManager.LoadScene(cutsceneNo);
			}

		}
}