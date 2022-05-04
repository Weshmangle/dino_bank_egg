using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]private float m_speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Movement();
    }

    private void Movement()
    {
        _rigidbody.velocity = Vector3.forward * m_speed * Time.deltaTime;
    }
}
