using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPC : MonoBehaviour
{
    private float _mouseYRotation = 0;
    private Quaternion _originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        _originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCameraUpAndDown();
    }

    private void RotateCameraUpAndDown()
    {
        _mouseYRotation += Input.GetAxis("Mouse Y");
        _mouseYRotation = Mathf.Clamp(_mouseYRotation, -50, 50);
        
        Quaternion upDown = Quaternion.AngleAxis(_mouseYRotation, Vector3.left);
        transform.localRotation = _originalRotation * upDown;
    }
}