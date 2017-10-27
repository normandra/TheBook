﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActManager : MonoBehaviour {

	public Text dialogueText;
	public Actions actions;

	private Queue<Act> acts;
	private Queue<string> sentences;

	private Act currentAct;
	private Actor currentActor;

	private bool talking;

	// Use this for initialization
	void Start () {
		acts = new Queue<Act> ();
		sentences = new Queue<string> ();

		talking = false;

		StartAct (actions);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			DisplayNextAct ();
		}
	}

	public void StartAct (Actions actions) {
		//empty our acts que and set it to the current active
		acts.Clear ();

		foreach (Act act in actions.acts) {
			acts.Enqueue (act);
		}

		//start the act
		DisplayNextAct ();
	}

	public void DisplayNextAct () {
		//check if we still have dialogue to display
		if(sentences.Count != 0){
			DisplayNextSentence (currentActor);
			return;
		}

		//if we are done with the dialogue
		if(talking){
			EndDialogue (currentActor);
		}

			
		//check if we still have an act
		if(acts.Count == 0){
			EndAct ();
			return;
		}

		//set the current act and check if its a dialogue or a transform/anim trigger
		currentAct = acts.Dequeue ();
			
		if(currentAct.isDialogue){
			//start the Dialogue 
			StartDialogue (currentAct);
		}else{
			Debug.Log ("invoking");
			currentAct.actorAbs.GetComponent<Actor> ().Invoke (currentAct.function, 0f);

		}

	}

	void EndAct() {
		
	}

	//DialogueSystem------------------------------------------------------------------

	void StartDialogue (Act act){
		//set text box to above character

		talking = true;

		Vector3 pos = Camera.main.WorldToScreenPoint (act.actorAbs.transform.position);
		dialogueText.transform.position = pos;
		dialogueText.transform.Translate (Vector3.up * 300, Space.World);

		sentences.Clear ();

		foreach (string sentence in act.dialogue.sentences)
		{
			sentences.Enqueue (sentence);
		}
		//start character animation
		currentActor = act.actor.GetComponent<Actor> ();
		currentActor.talk ();
		DisplayNextSentence (currentActor);
	}

	void DisplayNextSentence (Actor actor)
	{
		if (sentences.Count == 0){
			EndDialogue (actor);
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}



	void EndDialogue(Actor actor){
		StopAllCoroutines ();
		dialogueText.text = "";
		actor.idle ();
		talking = false;
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

}
