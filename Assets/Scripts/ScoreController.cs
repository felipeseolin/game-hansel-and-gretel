using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = GameController.candies.ToString();
    }
}
