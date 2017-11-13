using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noRotate : MonoBehaviour {


	private Quaternion rotation;

	void Awake(){
		rotation = transform.rotation;
	}

	void LateUpdate(){
		transform.rotation = rotation;
	}
}
