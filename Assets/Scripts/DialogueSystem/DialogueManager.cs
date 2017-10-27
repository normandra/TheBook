//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class DialogueManager : MonoBehaviour {
//
//	public Text dialogueText;
//
//	private Queue<string> sentences;
//
//
//	// Use this for initialization
//	void Start () {
//		sentences = new Queue<string> ();
//	}
//
//	public void StartDialogue (Act act){
//
//		//set character to its talking animation
//		StickerGuyClick actor = act.actor.GetComponent<StickerGuyClick> ();
//
//		//set text box to above character
//		Vector3 pos = Camera.main.WorldToScreenPoint (act.actorAbs.transform.position);
//		dialogueText.transform.position = pos;
//		dialogueText.transform.Translate (Vector3.up * 200, Space.World);
//
//		sentences.Clear ();
//
//		foreach (string sentence in act.dialogue.sentences)
//		{
//			sentences.Enqueue (sentence);
//		}
//		DisplayNextSentence ();
//	}
//
//	public void DisplayNextSentence ()
//	{
//		if (sentences.Count == 0){
//			EndDialogue ();
//			return;
//		}
//
//		string sentence = sentences.Dequeue ();
//		StopAllCoroutines ();
//		StartCoroutine (TypeSentence (sentence));
//	}
//
//
//
//	void EndDialogue(){
//		
//	}
//
//	IEnumerator TypeSentence (string sentence)
//	{
//		dialogueText.text = "";
//		foreach (char letter in sentence.ToCharArray())
//		{
//			dialogueText.text += letter;
//			yield return null;
//		}
//	}
//}
