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
    public Text countDino;
    public Text containerCount;
    public Text incomePerSecond;
    public Text income;
   
    void Start()
    {
        Instance = this;
        buttonAddDino.onClick.AddListener(buttonClickAddDino);
        buttonUpContainer.onClick.AddListener(buttonLevelContainer);
    }

    private void buttonLevelContainer()
    {
        GameManager.Instance.container.LevelUp();
    }

    protected void buttonClickAddDino()
    {
        SpawnManager.Instance.SpawnDino();
    }

    private void Update()
    {
        UIManager.Instance.buttonAddDino.interactable = containerWillBeFull();
        containerCount.text = GameManager.Instance.container.currentCountDino + " / " + GameManager.Instance.container.limit;
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
