using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBox : Actor {

	public InputField input;
	// Use this for initialization
	public void Start () {
		input = GetComponent<InputField> ();
	}
	
	public void setName(){
		am.sc.playerName = input.text;
		am.DisplayNextAct ();
		Disable ();
	}

	public void setDonkeyName(){
		am.sc.donkeyName = input.text;
		am.DisplayNextAct ();
		Disable ();
	}
}
