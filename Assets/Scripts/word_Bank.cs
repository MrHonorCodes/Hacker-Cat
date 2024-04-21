using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class wordBank : MonoBehaviour
{
    //string filePath = @"Assets/text/jv.txt";
    //List<string> originalWords = new List<string>();
    //List<string> workingWords = new List<string>();
private string[] readIn = System.IO.File.ReadAllLines(Application.dataPath + "/text/jv.txt");

    private List<string> originalCode = new List<string>();
    private List<string> code = new List<string>();
void Awake()
{
    try
    {
        List<string> originalCode = new List<string>(readIn);

        //read multiple lines to form a paragraph
        for (int i = 0; i < originalCode.Count; i+=3)
        {
            if (i + 2 < originalCode.Count)
            {
                // If there are at least 3 lines remaining, concatenate them
                code.Add(originalCode[i] + originalCode[i+1] + originalCode[i+2]);
            }
            else
            {
                // If there are less than 3 lines remaining, concatenate what's left
                string remainingLines = string.Empty;
                for (int j = i; j < originalCode.Count; j++)
                {
                    remainingLines += originalCode[j];
                }
                code.Add(remainingLines);
                break;
            }
        }
    }
    catch (IOException e)
    {
        Debug.LogError("Could not read the file: " + e.Message);
    }
}
    public string GetWord()
    {
        string newWord = string.Empty;
        if (code.Count != 0)
        {
            newWord = code.Last();
            code.Remove(newWord);
        }
        // else
        // {
        //     code.AddRange(originalCode);
        //     newWord = "end";
        // }

        return newWord;
    }

}