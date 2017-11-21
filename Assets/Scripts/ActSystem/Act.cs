using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Actors {
	public GameObject actor;
	public string param;
	public bool isFunction;

}

[System.Serializable]
public class Dialogue {

	public GameObject actor;
	public Text text;

	[TextArea(3, 10)]
	public string[] sentences;

}

[System.Serializable]
public class Act {

	public bool isInteractive;
	public Dialogue dialogue;
	public Actors[] actors;

}
