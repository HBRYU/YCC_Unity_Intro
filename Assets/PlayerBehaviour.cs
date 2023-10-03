using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private void Start()
    {
        List<int> intList = new List<int>();
        intList.Add(5);  // Adds 5 to the list
        intList.Add(6);  // Adds 6 to the list
        
        // Removes item at index 0
        intList.RemoveAt(0);  
        // print index of item 6 
        print(intList.IndexOf(6));
    }
}
