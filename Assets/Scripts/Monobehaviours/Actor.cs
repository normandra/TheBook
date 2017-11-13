using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour {

	Animator anim;
	int talkHash = Animator.StringToHash ("Talk");
	int idleHash = Animator.StringToHash ("Idle");
	int moveLeftFlipHash = Animator.StringToHash ("moveLeftFlip");

	private SceneController  sc;
	public ActManager am;
	private InputField input;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		input = GetComponent<InputField> ();
	} 

	public void setName(){
		am.sc.name = input.text;
		am.DisplayNextAct ();
		Disable ();
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
		am.DisplayNextAct();
	}

	public void goToSceneA(){
		sc.FadeAndLoadScene ("A");
	}

	public void goToSceneB(){
		sc.FadeAndLoadScene ("B");
	}

	public void Enable(){
		gameObject.SetActive (true);
	}

	public void Disable(){
		gameObject.SetActive (false);
	}
}
