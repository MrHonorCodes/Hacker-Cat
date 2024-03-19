using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // create word bank
    public wordBank wbank = null; 
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    // Start is called before the first frame update
    private void Start()
    {
        setCurrentWord();
    }

    public void setCurrentWord()
    {
        // get new word from bank word
        currentWord = wbank.getWord();
        setRemainingWord(currentWord);
    }

    public void setRemainingWord(string newStr)
    {
        remainingWord = newStr;
        //outputs current word to the display
        if (remainingWord.Length > 0)
        {
            // Split the remaining word into the first letter and the rest
            string firstLetter = remainingWord.Substring(0, 1);
            string restOfWord = remainingWord.Substring(1);

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
        checkInput();
    }

    private void checkInput()
    {
        //if any key is pressed check it
        if (Input.anyKeyDown)
        {
            //get the string inputted by user in this keyframe
            string pressedKey = Input.inputString;

            //check if the player pressed one key
            if(pressedKey.Length == 1)
            {
                enteredLetter(pressedKey);
            }
        }
    }

    private void enteredLetter(string typedLet)
    {
        if (isCorrectLetter(typedLet))
        {
            removeLetter();

            //check if word is complete after deleting a letter
            if (wordComplete())
            {
                setCurrentWord();
            }
        }
    }

    private bool isCorrectLetter(string letter)
    {
        //returns true if the index of the letter is 0
        return remainingWord.IndexOf(letter) == 0;
    }


    private void removeLetter()
    {
        // remove the first letter of the string and return the rest of the string
        string subStr = remainingWord.Remove(0, 1);
        setRemainingWord(subStr);
    }


    private bool wordComplete()
    {
        return remainingWord.Length == 0;
    }
}
