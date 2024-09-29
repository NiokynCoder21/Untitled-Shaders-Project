using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDialougue :  DialougeManager
{
    void Update()
    {
        if (isMover == true)
        {
            ShowNextLine(); // Show the next line of dialogue
            print("yes");
            Reset();
        }
    }
}
