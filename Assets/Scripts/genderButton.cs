using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class genderButton : MonoBehaviour {

	public ActManager am;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void boy(){
		am.sc.gender = "male";
		am.DisplayNextAct ();
	}


	public void girl(){
		am.sc.gender = "female";
		am.DisplayNextAct ();
	}
}
