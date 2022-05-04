using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] public DataDino data;

    private void Update()
    {
        Vector3 pos = GameManager.Instance._objectif.transform.position - transform.position;
        if(pos.magnitude < 0.2)
        {
            UIManager.Instance.RefreshValues(this);
            Destroy(gameObject);
        }
    }
}
