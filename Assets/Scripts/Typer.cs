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
        current = wordBank.getWord();
        setRemainder(current);
    }

    private void setRemainder(string newWord)
    {
        remainder = newWord;
        wordOutput.text = remainder;
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
