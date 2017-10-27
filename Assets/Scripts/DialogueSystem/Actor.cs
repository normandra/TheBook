using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	Animator anim;
	int talkHash = Animator.StringToHash ("Talk");
	int idleHash = Animator.StringToHash ("Idle");
	int moveLeftFlipHash = Animator.StringToHash ("moveLeftFlip");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	public void talk(){
		anim.SetTrigger (talkHash);
	}

	public void idle(){
		anim.SetTrigger (idleHash);
	}

	public void nothing(){
		
	}

	public void moveLeftFlip(){
		anim.SetTrigger (moveLeftFlipHash);
	}

	public void nextAct(){
		FindObjectOfType<ActManager> ().DisplayNextAct();
	}
}
