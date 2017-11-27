using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;
using System.Text.RegularExpressions;

public class ActManager : MonoBehaviour {

	public Text contText;

	private Text dialogueText;
	public SceneController sc;

	public Actions actions;

	private Queue<Act> acts;
	private Queue<string> sentences;

	private Act currentAct;
	private Actor currentActor;

	private bool talking;
	private bool cor;

	private Regex yourRegex;


	void Awake (){
		sc = FindObjectOfType<SceneController> ();
	}

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		acts = new Queue<Act> ();
		sentences = new Queue<string> ();

		talking = false;
		cor = false;

		StartAct (actions);
	}

	// Update is called once per frame
	void Update () {


		//check if we are currently supposed to be making a decision
		if(currentAct.isInteractive == false && cor == false){
			contText.gameObject.SetActive (true);
			if (Input.GetMouseButtonDown (0)) {
				DisplayNextAct ();
			}
		}else{
			contText.gameObject.SetActive (false);
		}



	}

	private void displayClickAble(){
		
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
		float AnimationDuration = 0f;

		if(currentAct.dialogue.sentences.Length > 0 ){
			//start the Dialogue 
			StartDialogue (currentAct);
			foreach (Actors actor in currentAct.actors) {

				Actor a = actor.actor.GetComponent<Actor> ();

				if(actor.isNotAnimation){
					a.Invoke (actor.param, 0f);
				}else{
					a.setAnimation (actor.param);
					if(actor.duration > AnimationDuration){
						AnimationDuration = actor.duration;
					}
				}
			}
			if(AnimationDuration > 0f){
				this.Invoke ("DisplayNextAct", AnimationDuration);
			}

		}else{
			foreach (Actors actor in currentAct.actors) {

				Actor a = actor.actor.GetComponent<Actor> ();

				if(actor.isNotAnimation){
					a.Invoke (actor.param, 0f);
				}else{
					a.setAnimation (actor.param);
					if(actor.duration > AnimationDuration){
						AnimationDuration = actor.duration;
					}
				}
			}
			if(AnimationDuration > 0f){
				this.Invoke ("DisplayNextAct", AnimationDuration);
			}
		}



	}

	void EndAct() {

	}

	//DialogueSystem------------------------------------------------------------------

	void StartDialogue (Act act){
		//set text box to above character

		talking = true;


		dialogueText = act.dialogue.text;
		dialogueText.transform.parent.gameObject.SetActive (true);

		sentences.Clear ();

		foreach (string sentence in act.dialogue.sentences)
		{
			sentences.Enqueue (sentence);
		}
		//start character animation
		currentActor = act.dialogue.actor.GetComponent<Actor> ();
		currentActor.talk ();
		DisplayNextSentence (currentActor);
	}

	string replaceName (string input){
		yourRegex = new Regex(@"\{([^\}]+)\}");
		input = yourRegex.Replace (input,sc.playerName);
		yourRegex = new Regex (@"\[[^]]*\]");
		return yourRegex.Replace (input,sc.donkeyName);
	}

	void DisplayNextSentence (Actor actor)
	{
	
		dialogueText.transform.parent.gameObject.SetActive (false);
		if (sentences.Count == 0){
			EndDialogue (actor);
			return;
		}
		dialogueText.transform.parent.gameObject.SetActive (true);
		string sentence = replaceName(sentences.Dequeue ());
		dialogueText.text = sentence;
		//StartCoroutine (TypeSentence (sentence));
	}



	void EndDialogue(Actor actor){
		StopAllCoroutines ();
		dialogueText.text = "";
		actor.idle ();
		dialogueText.transform.parent.gameObject.SetActive (false);
		talking = false;
	}

	IEnumerator TypeSentence (string sentence)
	{
		cor = true;
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}

		cor = false;
	}
}
