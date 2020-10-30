using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private int _index = 0;

    public GameObject pc;
    public GameObject[] waypoints = new GameObject[5];
    public float maxDistanceWaypoint = 2;
    public float maxDistancePC = 15;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(new Vector3(-90, 0, 270)));
        NextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(-90, transform.rotation.y, 270));
        if (Vector3.Distance(transform.position, pc.transform.position) <= maxDistancePC)
        {
            _agent.SetDestination(pc.transform.position);
        }
        else if (Vector3.Distance(transform.position, _agent.destination) <= maxDistanceWaypoint)
            NextWaypoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.PcHasDead();
        }
    }

    private void NextWaypoint()
    {
        _agent.SetDestination(waypoints[_index++].transform.position);
        if (_index >= waypoints.Length)
            _index = 0;
    }
}