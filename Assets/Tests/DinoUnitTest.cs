using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DinoSpace;

public class DinoUnitTest
{
    List<DataDino> _listOfDinos; 
    Container container;
    [SetUp]
    public void Setup()
    {
        container = new GameObject().AddComponent<Container>();
        container.data = ScriptableObject.CreateInstance<DataContainer>();
        container.data.limit = 50;
        container.data.cost = 1.75f;
        container.currentCountDino = 0;
        container.limit = container.data.limit;
    }

    /*Spawn MANAGER*/

    //SpawnDino


    /*SHOP*/

    //GetNextDino

    //BuyNextDino

    //SortListByCost


    /*GAME MANAGER*/

    //AddDino

    //GoToDestination


    /*CONTAINER*/

    //AddDinoToContainer
    
    [Test]
    public void ContainerIsFullAfterAddMMaxDinoUnitTestWithEnumeratorPasses()
    {
        container.currentCountDino = 0;
        for (int i = 0; i < container.limit; i++)
        {
            container.AddDinoToContainer();
        }
        Assert.IsTrue(container.isFull(), "Container is not Full"); 
    }
    
   [Test]
    public void ContainerNotIsFullAfterAdd2DinoUnitTestWithEnumeratorPasses()
    {
        container.currentCountDino = 0;
        for (int i = 0; i < 10; i++)
        {
            container.AddDinoToContainer();
        }
        Assert.IsFalse(container.isFull());
    }
    
    [Test]
    public void ContainerIsFullWhenAddOver50Dinos()
    {
        container.currentCountDino = 0;
        try
        { 
            for (int i = 0; i < container.limit + 10; i++)
            {
                container.AddDinoToContainer();
            }
        }
        catch(UnityException ex)
        {
        }
        Assert.IsTrue(container.isFull());
    }

    //[Test]
    public void ContainerLevelUp()
    {
        container.cost = 10;
        container.data.factorCost = 1.75f;

        var nextCost = container.NextCost();

        container.LevelUp();

        Assert.IsTrue(container.cost == nextCost, "NextCost not matching expected value");
    }
}
