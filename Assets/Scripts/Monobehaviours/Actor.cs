using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering;

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
		am.sc.FadeAndLoadScene ("3MapGerSwitz");
	}

	public void changeToGermany(){
		am.sc.FadeAndLoadScene ("2Germany");
	}

	public void goToSwFr(){
		am.sc.FadeAndLoadScene("4SwitzForest");
	}

	public void goToHouse(){
		am.sc.FadeAndLoadScene ("5SwissHouse");
	}

	public void goToSwissOutdoor(){
		am.sc.FadeAndLoadScene ("6SwissOutdoor");
	}

	public void goToValleyScene(){
		am.sc.FadeAndLoadScene ("7ValleyScene");
	}

	public void goToFinal(){
		am.sc.FadeAndLoadScene ("8Final");
	}
}

