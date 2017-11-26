using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protagonist : MonoBehaviour {

	public ActManager am;
	public Sprite daughter;

	// Use this for initialization
	void Start () {

		if(am.sc.gender == "female"){
			this.GetComponent<SpriteRenderer> ().sprite = daughter;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
