using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private float _originalRange;
    private Light _flashlight;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _flashlight = GetComponent<Light>();
        _originalRange = _flashlight.range;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleLight();
    }

    private void ToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _flashlight.range = _flashlight.range == 0 ? _originalRange : 0;
            _audioSource.Play();
        }
    }
    
}
