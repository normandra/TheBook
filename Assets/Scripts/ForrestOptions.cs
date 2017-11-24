using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ForrestOptions : MonoBehaviour {

	public ActManager am;
	public Actors[] actors;

	public void changeToRun(){
		foreach (var actors in actors) {
			actors.actor.GetComponent<Actor> ().setAnimation (actors.param);
		}
			
		this.Invoke ("changeToRunForrest", 1f);

	}

	public void changeToRunForrest(){
		am.sc.FadeAndLoadScene ("5SwitzerlandRun");
	}

	public void stay(){
		am.DisplayNextAct ();
	}

}
