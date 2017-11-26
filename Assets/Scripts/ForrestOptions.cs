using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrestOptions : MonoBehaviour {

	public ActManager am;
	public Actors[] actors;

	public void changeToRun(){
		foreach (var acto in actors) {
			acto.actor.GetComponent<Actor> ().setAnimation (acto.param);
		}
			
		this.Invoke ("changeToRunForrest", 1f);

	}

	public void changeToRunForrest(){
		am.sc.FadeAndLoadScene ("4SwitzForrestRun");
	}

	public void stay(){
		am.DisplayNextAct ();
	}

}
