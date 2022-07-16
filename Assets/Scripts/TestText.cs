using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestText : MonoBehaviour
{
    // Start is called before the first frame update
    string path = @"C:\Users\Dell\OneDrive\Documents\test.txt";
    char[] ignore = { ' ', '\n' };
    void Start()
    {
        string readText = File.ReadAllText(path);
        string[] texts = readText.Split(ignore);
        foreach (string x in texts)
        {
            Debug.Log(x);
        }
    }

    // Update is called once per frame
}
