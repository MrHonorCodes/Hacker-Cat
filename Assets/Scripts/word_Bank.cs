using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class wordBank : MonoBehaviour
{
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

            // fileNames array should only contain the filenames without extension, assuming they are .txt
            string[] fileNames = { "java1", "python1", "java2", "c1", "cs1", "java3" };

            // Use Resources.Load to access the text file associated with the current level
            TextAsset textFile = Resources.Load<TextAsset>(fileNames[currentLevel - 1]);

            if (textFile != null)
            {
                // Split the file into lines and add them to the code list
                string[] lines = textFile.text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                ProcessLines(lines);
            }
            else
            {
                Debug.LogError("Could not load the text file: " + fileNames[currentLevel - 1]);
            }
    }

    private void ProcessLines(string[] lines)
    {
        for (int i = 0; i < lines.Length; i += 4)
        {
            string paragraph = "";
            for (int j = i; j < i + 4 && j < lines.Length; j++)
            {
                paragraph += lines[j];
                if (j < i + 3 && j < lines.Length - 1)
                    paragraph += "\n";
            }
            code.Add(paragraph);
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