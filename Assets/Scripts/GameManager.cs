using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _objectif;
    
    private void Start()
    {
        Instance = this;
        
    }

    public void GotoDestination(GameObject dino)
    {
        dino.GetComponent<NavMeshAgent>().SetDestination(_objectif.transform.position);
    }
}
