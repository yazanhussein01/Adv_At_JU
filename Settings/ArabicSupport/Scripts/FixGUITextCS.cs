using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ArabicSupport;

public class FixGUITextCS : MonoBehaviour {
	
	public string text;
	public bool tashkeel = true;
	public bool hinduNumbers = true;

	[SerializeField] GameObject noButton;

	[SerializeField] string[] lines;
	[SerializeField] float textSpeed;
	string tempString;
	int index;
	
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Text>().text = ArabicFixer.Fix(text, tashkeel, hinduNumbers);
		//StartDialogue();
	}

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
			if (gameObject.GetComponent<Text>().text == ArabicFixer.Fix(lines[index], tashkeel, hinduNumbers))
            {
				nextLine();
				noButton.SetActive(true);
			}

			else
			{
				StopAllCoroutines();
				gameObject.GetComponent<Text>().text = ArabicFixer.Fix(lines[index], tashkeel, hinduNumbers);
			}
		}
        
	}

	public void StartDialogue()
    {
		index = 0;
		StartCoroutine(typeLine());
    }

	IEnumerator typeLine()
	{
		tempString = "";
		foreach (char c in lines[index].ToCharArray())
		{
			tempString += c;
			gameObject.GetComponent<Text>().text = ArabicFixer.Fix(tempString, tashkeel, hinduNumbers);
			yield return new WaitForSeconds(textSpeed);
		}
		if (index == 5)
			noButton.SetActive(true);
	}

	void nextLine()
    {

		if (index < lines.Length - 1)
        {
			index++;

			gameObject.GetComponent<Text>().text = "";
			StartCoroutine(typeLine());
		}
		else
        {
			gameObject.SetActive(false);
        }
    }
}
