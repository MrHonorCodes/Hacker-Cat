using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordBank : MonoBehaviour
{
    string filePath = @"Assets/text/hello.txt";
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

            foreach(string word in workingWords)
            { 

                Debug.Log(word);
            }
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
            string newWord = workingWords[0];
            workingWords.RemoveAt(0);
            return newWord;
        }
        return string.Empty;
    }
}
