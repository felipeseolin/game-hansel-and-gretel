using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject pc;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(new Vector3(-90, 0, 270)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(-90, transform.rotation.y, 270));
        _agent.SetDestination(pc.transform.position);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.PcHasDead();
        }
    }
}