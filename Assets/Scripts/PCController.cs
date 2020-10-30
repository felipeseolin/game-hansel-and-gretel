using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PCController : MonoBehaviour
{
    private Rigidbody _rdb;
    private Quaternion _originalRotation;
    private float _mouseXRotation = 0;
    private AudioSource _audio;

    public float velocity = 5;
    public float velocityRotation = 100;
    public LayerMask target;

    // Start is called before the first frame update
    void Start()
    {
        _rdb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        MovePC();
        RotatePC();
        Shoot();
    }

    private void MovePC()
    {
        float moveFoward = Input.GetAxis("Vertical");
        float moveSide = Input.GetAxis("Horizontal");

        Vector3 v3Velocity = new Vector3(
            moveSide * velocity, _rdb.velocity.y, moveFoward * velocity
        );
        _rdb.velocity = transform.TransformDirection(v3Velocity);
        
        if (!_audio.isPlaying && (moveFoward != 0f || moveSide != 0f))
            _audio.Play();
    }

    private void RotatePC()
    {
        // Using keyboard Q and E
        int keyboardRotation = 0;
        if (Input.GetKey(KeyCode.Q))
            keyboardRotation = -1;
        else if (Input.GetKey(KeyCode.E))
            keyboardRotation = 1;

        transform.Rotate(new Vector3(
            0, keyboardRotation * Time.deltaTime * velocityRotation, 0
        ));

        // Using mouse
        _mouseXRotation += Input.GetAxis("Mouse X");
        Quaternion side = Quaternion.AngleAxis(_mouseXRotation, Vector3.up);
        transform.localRotation = _originalRotation * side;
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.O)
        )
        {
            RaycastHit hit;
            if (Physics.Raycast(
                transform.position,
                transform.forward,
                out hit,
                100,
                target)
            )
            {
                Rigidbody rbd = hit.collider.gameObject.GetComponent<Rigidbody>();
                rbd.AddForce(transform.forward * 500);
            }
        }
    }
}