using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class generateUrl : MonoBehaviour {

	SceneController sc;
	String url = "http://norboy.de/bookService/";

	int gender = 1;
	int decision = 1;
	String playerName;

	// Use this for initialization
	void Start () {
		sc = FindObjectOfType<SceneController> ();
		if(sc.gender == "female"){
			gender = 0;
		}

		if(sc.decision == 0){
			decision = 0;
		}

		playerName = sc.playerName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openBook(){
		Application.OpenURL (url + "?s=" + gender +"&d=" + decision+"&name="+playerName);
	}
}
