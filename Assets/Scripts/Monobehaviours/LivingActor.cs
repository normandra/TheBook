using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingActor : Actor {

	public Animator anim;

	// Use this for initialization
	public virtual void Start () {
		
	}

	public void talk(){
		anim.SetTrigger ("Talk");
	}

	public void idle(){
		anim.SetTrigger ("Idle");
	}

}
