using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;
    private int countEnclosure;
       
    void Start()
    {
        button.onClick.AddListener(buttonClickAddDino);
    }

    protected void buttonClickAddDino()
    {
        SpawnManager.Instance.SpawnDino();
        countEnclosure++;
        text.text = "Spawn : " + countEnclosure;
    }
}
