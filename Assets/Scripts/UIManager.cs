using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] public Button buttonAddDino;
    [SerializeField] public Button buttonUpContainer;
    [SerializeField] public Button buttonUpDino;
    public Text countDino;
    public Text containerCount;
    public Text incomePerSecond;
    public Text income;
   
    void Start()
    {
        Instance = this;
        buttonAddDino.onClick.AddListener(onClickButtonClickAddDino);
        buttonUpContainer.onClick.AddListener(onClickButtonLevelContainer);
        buttonUpDino.onClick.AddListener(onClickButtonClickUpDino);
    }

    private void onClickButtonLevelContainer()
    {
        GameManager.Instance.container.LevelUp();
    }

    protected void onClickButtonClickAddDino()
    {
        SpawnManager.Instance.SpawnDino();
    }
    protected void onClickButtonClickUpDino()
    {
        Shop.Instance.BuyNextDino();
    }

    private void Update()
    {
        var container = GameManager.Instance.container;
        
        buttonAddDino.interactable = containerWillBeFull();
        buttonUpContainer.interactable = GameManager.Instance.incomeTotal > GameManager.Instance.container.NextCost();
        buttonUpDino.interactable = GameManager.Instance.incomeTotal > Shop.Instance.GetNextDataDino().costOfDino;
        containerCount.text = container.currentCountDino + " / " + container.limit;
        buttonUpContainer.GetComponentInChildren<Text>().text = $" Up Container {Mathf.FloorToInt(container.cost * container.data.factorCost)} $ ";
        
        if(Shop.Instance.GetNextDataDino())
        {
            buttonUpDino.GetComponentInChildren<Text>().text = $" Up Dino {Shop.Instance.GetNextDataDino().costOfDino} $ ";
        }
        else
        {
            buttonUpDino.GetComponentInChildren<Text>().text = $" Up Dino ( MAXIMUM LEVEL ) ";
        }
    }

    private bool containerWillBeFull()
    {
        var container = GameManager.Instance.container;
        return !(container.isFull() || 
        container.currentCountDino + SpawnManager.Instance.dinosInstanciated.Count >= container.limit);
    }

    public void Refresh()
    {
        countDino.text = "Dinos : " + GameManager.Instance.countDino;
        incomePerSecond.text = "Income : " + GameManager.Instance.incomePerSeconde + " $/s";
    }
}
