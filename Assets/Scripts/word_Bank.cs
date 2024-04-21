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

    void Awake()
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

    public string GetWord()
    {
        if (workingWords.Count > 0)
        {
            String newWord = "";

            foreach (String sentence in workingWords)
            {
                newWord += sentence;
            }

            workingWords.RemoveRange(0, workingWords.Count);

            Debug.Log(newWord);
            return newWord;
        }
        return string.Empty;
    }

}