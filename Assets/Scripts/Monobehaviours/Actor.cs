using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Actor : MonoBehaviour {

	public ActManager am;
	public Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	
	}

	public void nextAct(){
		am.DisplayNextAct();
	}

	public void Enable(){
		gameObject.SetActive (true);
	}

	public void Disable(){
		gameObject.SetActive (false);
	}

	public void setAnimation(String triggerCondition){
		anim.SetTrigger (triggerCondition);
	}

	public void talk(){
		anim.SetTrigger ("Talk");
	}

	public void idle(){
		anim.SetTrigger ("Idle");
	}

	public void changeToMapGS(){
		am.sc.FadeAndLoadScene ("Switzerland 1");
	}


}

