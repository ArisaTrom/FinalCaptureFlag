using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*
 * Arisa Takenaka Trombley & Sam Lash
 * 2375446 2366917
 * trombley@chapman.edu slash@chapman.edu
 * CPSC-245-01
 * Final
 * 
 */
public class Dictionary : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, string> myDict = new Dictionary<int, string>();
    void Start()
    {
        // Adding key/value pairs in myDict
        myDict.Add(0 , "You did it!");
        myDict.Add(1 , "You suck.");
        myDict.Add(2 , "Well, you tried. More than I can usually say.");
    }

    public string displayAchievement(int achievementKey)
    {
        string achievementText = myDict.ElementAt(achievementKey).Value;
        return achievementText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
