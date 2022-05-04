using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]private List<DataDino> _listOfDinos = new List<DataDino>();

    private int _indexOfActualDino;
    

    private void Start()
    {
        SortListByCost();
        _indexOfActualDino = 0;
        //GameManager.Instance.incomePerSeconde = _listOfDinos[_indexOfActualDino].moneyPerSecond;
        GameManager.Instance.valueOfDino = _listOfDinos[_indexOfActualDino].moneyPerSecond;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BuyNextDino();
        }
    }

    private void BuyNextDino()
    {
        if (_indexOfActualDino+1 >= _listOfDinos.Count)
        {
            Debug.Log("Vous avez déjà atteint le meilleur dino !");
            return;
        }

        if (GameManager.Instance.incomeTotal < _listOfDinos[_indexOfActualDino+1].costOfDino)
        {
            Debug.Log("Vous n'avez pas assez d'argent !");
            return;
        }
        
        _indexOfActualDino++;
        Debug.Log($"Bien joué vous avez acheté le dino suivant : {_listOfDinos[_indexOfActualDino].nameDino}.");
        GameManager.Instance.valueOfDino = _listOfDinos[_indexOfActualDino].moneyPerSecond;
        GameManager.Instance.incomeTotal -= _listOfDinos[_indexOfActualDino].costOfDino;
    }

    private void SortListByCost()
    {
        for (int i = 0; i < _listOfDinos.Count; i++)
        {
            for (int j = i+1; j < _listOfDinos.Count-1; j++)
            {
                if (_listOfDinos[i].costOfDino > _listOfDinos[j].costOfDino)
                {
                    (_listOfDinos[i], _listOfDinos[j]) = (_listOfDinos[j], _listOfDinos[i]);
                }
            }
        }
    }
}
