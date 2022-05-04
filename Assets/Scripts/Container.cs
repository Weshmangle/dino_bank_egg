using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public int currentCountDino;
    
    public int limit;
    public float cost;

    public DataContainer data;

    private void Awake()
    {
        currentCountDino = 0;
        limit = data.limit;
        cost = data.cost;
    }

    public void AddDinoToContainer()
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
        return currentCountDino == limit; 
    }

    public float NextCost()
    {
        return cost * data.factorCost;
    }

    public void LevelUp()
    {
        var costNextLevel = cost * data.factorCost;
        
        if(GameManager.Instance.incomeTotal > costNextLevel)
        {
            cost = costNextLevel;
            limit = Mathf.FloorToInt(limit * data.factorLimit);
            GameManager.Instance.incomeTotal = GameManager.Instance.incomeTotal - costNextLevel;
        }
        else
        {
            Debug.Log("No enough money " + costNextLevel);
        }
    }
}
