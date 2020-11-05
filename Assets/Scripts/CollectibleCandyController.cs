using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCandyController : MonoBehaviour
{
    private AudioSource _candyAudio;

    // Start is called before the first frame update
    void Start()
    {
        _candyAudio = GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(new Vector3(-54.346f, -60.822f, 85.83301f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Desactivate), 1.5f);
            _candyAudio.Play();
            GameController.IncreaseCandy();
        }
    }

    private void Desactivate()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}