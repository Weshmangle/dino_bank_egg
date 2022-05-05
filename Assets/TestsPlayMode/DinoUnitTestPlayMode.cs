using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DinoSpace;

public class DinoUnitTestPlayMode
{
    DataDino dino_1;
    DataDino dino_2;
    GameObject go;
    GameManager gameManager;
    Shop shop;
    SpawnManager spawnManager;
    [SetUp]
    public void Setup()
    {
        go = new GameObject();
        shop = go.AddComponent<Shop>();
        gameManager = go.AddComponent<GameManager>();
        spawnManager = go.AddComponent<SpawnManager>();
        spawnManager.prefab = CreateMockDino();
        dino_1 = ScriptableObject.CreateInstance<DataDino>();
        dino_2 = ScriptableObject.CreateInstance<DataDino>();
        dino_1.costOfDino = 50;
        dino_2.costOfDino = 25;
        shop.GetListDino().Add(dino_1);
        shop.GetListDino().Add(dino_2);
    }

    /*SHOP*/

    //GetNextDino

    //BuyNextDino

    [Test]
    public void TestAlreadyLastDino()
    {
        int lastIndex = go.GetComponent<Shop>().GetListDino().Count;
        go.GetComponent<Shop>().SetIndexOfActualDino(lastIndex);
        go.GetComponent<Shop>().BuyNextDino();
        Assert.IsTrue(go.GetComponent<Shop>().GetIndexOfActualDino() == lastIndex);

    }

    [Test]
    public void TestYouDontHaveMoneyToBuy()
    {
        go.GetComponent<GameManager>().SetIncomeTotal(10);
        Debug.Log(go.GetComponent<Shop>().GetListDino().Count);
        go.GetComponent<Shop>().SortListByCost(go.GetComponent<Shop>().GetListDino());
        go.GetComponent<Shop>().BuyNextDino();
        Assert.IsTrue(go.GetComponent<GameManager>().GetIncomeTotal() == 10);
    }

    [Test]
    public void TestBuyNextDino()
    {
        float initialIncome = 10000;
        gameManager.SetIncomeTotal(initialIncome);
        shop.SortListByCost(shop.GetListDino());
        shop.BuyNextDino();
        Assert.IsTrue(gameManager.GetIncomeTotal() == initialIncome - shop.GetListDino()[shop.GetIndexOfActualDino()].costOfDino);
    }

    //SortListByCost
    [Test]
    public void TestSortingListByCost()
    {
        go.GetComponent<Shop>().SortListByCost(go.GetComponent<Shop>().GetListDino());
        Assert.IsTrue(go.GetComponent<Shop>().GetListDino()[0].costOfDino < go.GetComponent<Shop>().GetListDino()[1].costOfDino);
    }

    private GameObject CreateMockDino()
    {
        var go = new GameObject();
        go.AddComponent<Dino>().data = dino_1;

        return go;
    }
}
