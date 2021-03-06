
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class UITextTypeWriter : MonoBehaviour 
{

	Text txt;
string story;
	Button button;

void Awake()
{
	txt = GetComponent<Text>();
	story = txt.text;
	txt.text = "";
	button = FindObjectOfType<Button>();
	button.gameObject.SetActive(false);

	// TODO: add optional delay when to start
		StartCoroutine("PlayText");
}

IEnumerator PlayText()
{
	foreach (char c in story)
	{
		txt.text += c;
		yield return new WaitForSeconds(0.075f);
	}
		button.gameObject.SetActive(true);

	}

}