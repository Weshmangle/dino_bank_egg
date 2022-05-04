using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _objectif;
    [SerializeField] private NavMeshAgent _agent;
    private void Start()
    {
        _agent.SetDestination(_objectif.transform.position);
    }
}
