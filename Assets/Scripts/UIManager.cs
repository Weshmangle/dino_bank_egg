using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Button button;
    public Text countDino;
    public Text incomePerSecond;
    public Text income;
   
    void Start()
    {
        Instance = this;
        button.onClick.AddListener(buttonClickAddDino);
    }

    protected void buttonClickAddDino()
    {
        SpawnManager.Instance.SpawnDino();
    }

    public void RefreshValues(Dino dino)
    {
        GameManager.Instance.countDino++;
        GameManager.Instance.incomePerSeconde += GameManager.Instance.valueOfDino;

        countDino.text = "Spawn : " + GameManager.Instance.countDino;
        incomePerSecond.text = "Income : " + GameManager.Instance.incomePerSeconde + " $/s";
    }
}
