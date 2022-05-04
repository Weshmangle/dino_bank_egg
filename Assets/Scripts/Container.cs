using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public int currentCountDino = 0;
    
    public int countMaxDino = 50;

    public void addDino()
    {
        if(!isFull())
        {
            currentCountDino++;
        }
        else
        {
            throw new UnityException("Container is full");
        }
    }

    public bool isFull()
    {
        return currentCountDino == countMaxDino;
    }
}
