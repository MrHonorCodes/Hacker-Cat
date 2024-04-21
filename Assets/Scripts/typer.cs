using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        remainingWord = newStr.Trim();
        //outputs current word to the display
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
                    // Check if the current scene is "FinalLevel"
            if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "FinalLevel")
            {
                // If it is, load the "EndGameMenu" scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameMenu");
            }
            else
            {
                PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
                // If it's not, load the "LevelCompleteMenu" scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelCompleteMenu");
            }
            //wordOutput.text = "You Win :)";
        }
    }
    public void TypeLetter(char letter)
    {
        if (isNextLetter(letter))
        {
            // Remove the typed letter from the remaining word
            remainingWord = remainingWord.Remove(0, 1);
            // Update the display
            setRemainingWord(remainingWord);
        }
    }

    private bool isNextLetter(char letter)
    {
        return remainingWord.Length > 0 && remainingWord[0] == letter;
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