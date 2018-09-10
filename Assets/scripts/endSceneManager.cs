using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;
using UnityEngine.EventSystems;

public class endSceneManager : MonoBehaviour {
	public gameManager gm ;

	// Use this for initialization
	void Start () {
		gm = gameManager.instance;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sceneChange()
	{
			switch (gm.currentStage) {
			case (1):	
				print ("Its stage 1") ;

				SceneManager.LoadScene (5);
				break;
			case (2):	
				print ("Its stage 2") ;
				SceneManager.LoadScene (10);
				break;
			case (3):	
				SceneManager.LoadScene (15);
				break;
			case (4):	
				SceneManager.LoadScene (19);
				break;
			}
	}
}
