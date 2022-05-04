using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Rigidbody _rigidbody;
    private Vector3 target;
    [SerializeField] public DataDino data;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 pos = GameManager.Instance._objectif.transform.position - transform.position;
        if(pos.magnitude < 0.2)
        {
            GameManager.Instance.AddDino(this);
            UIManager.Instance.Refresh();
            SpawnManager.Instance.dinosInstanciated.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void Movement()
    {
        _rigidbody.velocity = Vector3.forward * m_speed * Time.deltaTime;
    }
}
