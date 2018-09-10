using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//manager reference
	public timerStart manager;

	//text elements
	public Text Hurry;
	public Text Timer;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Timer.text = manager.countdownValue.ToString ("F2");
	}
}
