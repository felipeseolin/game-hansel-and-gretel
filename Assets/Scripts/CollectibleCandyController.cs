using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCandyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(-54.346f,-60.822f,85.83301f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.IncreaseCandy();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
