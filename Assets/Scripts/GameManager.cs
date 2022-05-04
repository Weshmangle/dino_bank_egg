using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _objectif;
    [SerializeField] private NavMeshAgent agent;
    
    private void Start()
    {
        Instance = this;
        
    }

    private void Update() {
        agent.SetDestination(_objectif.transform.position);
    }

    public void GotoDestination(GameObject dino)
    {
        dino.GetComponent<NavMeshAgent>().SetDestination(_objectif.transform.position);
    }
}
