using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noRotate : MonoBehaviour {


	private Quaternion rotation;

	void Awake(){
		rotation = Quaternion.Euler (0,0,0);
	}

	void LateUpdate(){
		transform.rotation = rotation;
	}
}
