using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class wordBank : MonoBehaviour
{
    string filePath;
    //List<string> originalWords = new List<string>();
    //List<string> workingWords = new List<string>();
private string[] fileNames = { "java1.txt", "python1.txt", "java2.txt", "c1.txt", "cs1.txt", "java3.txt" };

private string[] readIn;

    private List<string> originalCode = new List<string>();
    private List<string> code = new List<string>();
void Awake()
{
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        int currentLevel = GetLevelFromSceneName(currentSceneName); // Get level number from scene name

        if (currentLevel < 1 || currentLevel > 6)
        {
            Debug.LogError("Invalid level number: " + currentLevel);
            return;
        }

        // Use the currentLevel to set the filePath from fileNames array
        filePath = Application.dataPath + "/text/" + fileNames[currentLevel - 1]; // Arrays are 0-indexed so subtract 1
        Debug.Log("Loading file from path: " + filePath);
        
        readIn = System.IO.File.ReadAllLines(filePath);

    try
    {
        List<string> originalCode = new List<string>(readIn);

        //read multiple lines to form a paragraph
        for (int i = 0; i < originalCode.Count; i+=4)
        {
            if (i + 3 < originalCode.Count)
            {
                // If there are at least 3 lines remaining, concatenate them
                code.Add(originalCode[i] + "\n" +  originalCode[i+1] + "\n" + originalCode[i+2] + "\n" + originalCode[i+3]);
            }
            else
            {
                // If there are less than 3 lines remaining, concatenate what's left
                string remainingLines = string.Empty;
                for (int j = i; j < originalCode.Count; j++)
                {
                    remainingLines += originalCode[j];
                    if (j < originalCode.Count - 1)
                    {
                        remainingLines += "\n"; // Add a newline character between lines
                    }
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
    if (code.Count > 0)
    {
        newWord = code[0];
        code.RemoveAt(0);
    }

    return newWord;
}

public bool IsCodeEmpty()
{
    return code.Count == 0;
}


        // Get level number from scene name
    private int GetLevelFromSceneName(string sceneName)
    {
        if (sceneName == "Level1_Dog")
        {
            return 1;
        }
        if (sceneName == "Level2")
        {
            return 2;
        }
        if (sceneName == "Level3")
        {
            return 3;
        }
        if (sceneName == "Level4")
        {
            return 4;
        }
        if (sceneName == "Level5")
        {
            return 5;
        }
        if (sceneName == "FinalLevel")
        {
            return 6;
        }
        return 0;
    }

}