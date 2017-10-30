using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	Animator anim;
	int talkHash = Animator.StringToHash ("Talk");
	int idleHash = Animator.StringToHash ("Idle");
	int moveLeftFlipHash = Animator.StringToHash ("moveLeftFlip");

	private SceneController  sc;
	private ActManager am;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		sc = FindObjectOfType<SceneController> ();
		am = FindObjectOfType<ActManager> ();
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
