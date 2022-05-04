using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] public Button buttonAddDino;
    public Text countDino;
    public Text incomePerSecond;
    public Text income;
   
    void Start()
    {
        Instance = this;
        buttonAddDino.onClick.AddListener(buttonClickAddDino);
    }

    protected void buttonClickAddDino()
    {
        SpawnManager.Instance.SpawnDino();
    }

    private void Update()
    {
        UIManager.Instance.buttonAddDino.interactable = containerWillBeFull();
    }

    private bool containerWillBeFull()
    {
        var container = GameManager.Instance.container;
        return !(container.isFull() || 
        container.currentCountDino + SpawnManager.Instance.dinosInstanciated.Count >= container.countMaxDino); 
    }

    public void Refresh()
    {
        countDino.text = "Spawn : " + GameManager.Instance.countDino;
        incomePerSecond.text = "Income : " + GameManager.Instance.incomePerSeconde + " $/s";
    }
}
