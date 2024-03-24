using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public WordBank wordBank = null;
    public Text wordOutput = null;
    
    private string remainder = string.Empty;
    private string current = string.Empty;

    // Start is called before the first frame update
    private void Start()
    {
        setCurrent();
    }

    private void setCurrent()
    {
        current = wordBank.GetWord();
        setRemainder(current);
    }

    private void setRemainder(string newWord)
    {
        remainder = newWord;

		//outputs current word to the display
        if (remainder.Length > 0)
        {
            // Split the remaining word into the first letter and the rest
            string firstLetter = remainder.Substring(0, 1);
            string restOfWord = remainder.Substring(1);

            // Use rich text tags to color the first letter red
            wordOutput.text = "<color=red>" + firstLetter + "</color>" + restOfWord;
        }
        else
        {
            wordOutput.text = "You Win :)";
        }
    }

    // Update is called once per frame
    private void Update()
    {
        checker();
    }

    private void checker()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
            {
                entered(keysPressed);
            }
        }
    }

    private void entered(string typed)
    {
        if(isCorrect(typed))
        {
            removeLetter();
            if(isComplete())
                setCurrent();
        }
    }

    private bool isCorrect(string typed)
    {
        return remainder.IndexOf(typed) == 0;
    }
    private void removeLetter()
    {
        string newWord = remainder.Remove(0, 1);
        setRemainder(newWord);
    }
    private bool isComplete()
    {
        return remainder.Length == 0;
    }
}
