﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public GameObject _objectif;
    public int countDino;
    public float incomePerSeconde;
    public float incomeTotal;
    public Container container;
    
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        incomeTotal += incomePerSeconde * Time.deltaTime;
        UIManager.Instance.income.text = incomeTotal.ToString();
    }

    public void AddDino(Dino dino)
    {
        countDino++;
        incomePerSeconde += dino.data.moneyPerSecond;
        container.addDino();
    }

    public void GotoDestination(GameObject dino)
    {
        dino.GetComponent<NavMeshAgent>().SetDestination(_objectif.transform.position);
    }
}
