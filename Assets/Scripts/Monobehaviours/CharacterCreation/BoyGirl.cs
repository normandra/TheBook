using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyGirl : LivingActor {



	// Use this for initialization
	public override void Start () {
		base.Start ();
	}

	public void moveRight(){
		Debug.Log ("call");
		anim.SetTrigger ("moveRight");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
