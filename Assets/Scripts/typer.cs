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

            string nextLetter = remainingPart.Length > 0 ? remainingPart.Substring(0, 1) : "";
            string restOfWord = remainingPart.Length > 1 ? remainingPart.Substring(1) : "";

            // Color the typed part red, the next letter (incorrectly typed) blue, and the rest grey
            // If the letter is incorrect, refresh the current display without removing a letter
            wordOutput.text = "<color=white>" + typedPart + "</color>" +
                              "<color=grey>" + nextLetter + "</color>" +
                              "<color=grey>" + restOfWord + "</color>";
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
            // Check if the player pressed an alphabetic character and handle case sensitivity
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
        else
        {
            // Calculate the number of letters the user has typed correctly
            int typedLength = currentWord.Length - remainingWord.Length;

            string typedPart = currentWord.Substring(0, typedLength);
            string remainingPart = currentWord.Substring(typedLength);
            string nextLetter = remainingPart.Length > 0 ? remainingPart.Substring(0, 1) : "";
            string restOfWord = remainingPart.Length > 1 ? remainingPart.Substring(1) : "";
            // If the letter is incorrect, refresh the current display without removing a letter
            wordOutput.text = "<color=white>" + typedPart + "</color>" +
                              "<color=red>" + nextLetter + "</color>" +
                              "<color=grey>" + restOfWord + "</color>";
        }
    }

    private bool isCorrectLetter(string letter)
    {
        // Ignore spaces by automatically considering them "correct"
        if (remainingWord[0] == ' ')
        {
            // Automatically skip over spaces
            removeLetter();
            return true;
        }
        //returns true if the index of the letter is 0
        return remainingWord.IndexOf(letter) == 0;
    }


    private void removeLetter()
    {
        // remove the first letter of the string and return the rest of the string
        // Remove the first character (already checked as correct or a space)
        remainingWord = remainingWord.Substring(1);

        // Continue removing if the next character is a space
        while (remainingWord.Length > 0 && remainingWord[0] == ' ')
        {
            remainingWord = remainingWord.Substring(1);
        }

        setRemainingWord(remainingWord);
    }


    private bool wordComplete()
    {
        return remainingWord.Length == 0;
    }
}