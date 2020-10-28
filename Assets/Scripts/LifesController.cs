using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifesController : MonoBehaviour
{
    private TextMeshProUGUI _numberOfLifesText;
    // Start is called before the first frame update
    void Start()
    {
        _numberOfLifesText = GetComponent<TextMeshProUGUI>();
        _numberOfLifesText.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        _numberOfLifesText.text = GameController.numberOfLifes.ToString();
    }
}
