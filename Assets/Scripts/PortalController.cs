using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Transform _cameraPosition;

    public GameObject pc;
    // Start is called before the first frame update
    void Start()
    {
        _cameraPosition = this.gameObject.transform.GetChild(0).gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pc.transform.position = _cameraPosition.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
