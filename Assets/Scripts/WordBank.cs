using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    //I can change this to read from a text file later
    private List<string> originalCode = new List<string>()
    {
        "string", "integer", "double", "float", "private", "void", "class"
    };

    private List<string> code = new List<string>();

    private void Awake()
    {
        code.AddRange(originalCode);
        shuffle(code);
        convertToLower(code);
    }

    private void shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(0, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void convertToLower(List<string> list)
    {
        for(int i = 0;i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string getWord()
    {
        string newWord = string.Empty;
        if(code.Count != 0)
        {
            newWord = code.Last();
            code.Remove(newWord);
        }
        else
        {
            code.AddRange(originalCode);
            newWord = "end";
        }
            
        return newWord;
    }

}
