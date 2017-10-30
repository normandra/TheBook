using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Actors {
	public GameObject actor;
	public string function;
}

[System.Serializable]
public class Dialogue {

	public GameObject actor;

	[TextArea(3, 10)]
	public string[] sentences;

}

[System.Serializable]
public class Act {

	public bool isDialogue;
	public bool isInteractive;
	public Dialogue dialogue;
	public Actors[] actors;

//	class Dialogue {
//
//		public string name;
//
//		[TextArea(3, 10)]
//		public string[] sentences;
//
//	}


}
