using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class wordBank : MonoBehaviour
{
    string filePath = @"Assets/text/jv.txt";
    List<string> originalWords = new List<string>();
    List<string> workingWords = new List<string>();

    void Start()
    {

        try
        {
            // Read all lines from the file and add them to the list
            originalWords.AddRange(File.ReadAllLines(filePath));
            // Initialize workingWords after originalWords is populated
            workingWords.AddRange(originalWords);
        }
        catch (IOException e)
        {
            Debug.LogError("Could not read the file: " + e.Message);
        }

    }

    public string getWord()
    {
        if (workingWords.Count > 0)
        {
            string newWord = workingWords[0];
            workingWords.RemoveAt(0);
            return newWord;
        }
        return string.Empty;
    }

}
