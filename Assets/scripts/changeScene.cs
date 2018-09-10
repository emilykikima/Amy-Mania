using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;
using UnityEngine.EventSystems;

public class changeScene : MonoBehaviour {

	public void sceneChange(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex) ;
	}
}