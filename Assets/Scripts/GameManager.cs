using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public GameObject _objectif;
    public int countDino;
    public float valueOfDino = 0;
    public float incomePerSeconde;
    public float incomeTotal;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        incomeTotal += incomePerSeconde * Time.deltaTime;
        UIManager.Instance.income.text = GameManager.Instance.incomeTotal.ToString();
    }

    public void GotoDestination(GameObject dino)
    {
        dino.GetComponent<NavMeshAgent>().SetDestination(_objectif.transform.position);
    }
}
