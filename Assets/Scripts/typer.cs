using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    // create word bank
    public wordBank wbank;
    public Text wordOutput;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private int indexLetter;

    // Start is called before the first frame update
    private void Start()
    {
        setCurrentWord();
    }

    public void setCurrentWord()
    {
        // get new word from bank word
        currentWord = wbank.GetWord();
        indexLetter = 0;
        setRemainingWord(currentWord);
    }

    public void setRemainingWord(string newStr)
    {
        remainingWord = newStr;
        //outputs current word to the display
        if (remainingWord.Length > 0)
        {
            // Calculate the number of letters the user has typed correctly
            int typedLength = currentWord.Length - remainingWord.Length;
            // Get the typed part and the remaining part of the word
            string typedPart = currentWord.Substring(0, typedLength);
            string remainingPart = currentWord.Substring(typedLength);

            // Use rich text tags to color the typed part red and concatenate with the remaining part
            wordOutput.text = "<color=red>" + typedPart + "</color>" + remainingPart;
        }
        else
        {            
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelCompleteMenu");
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
            if (pressedKey.Length == 1)
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