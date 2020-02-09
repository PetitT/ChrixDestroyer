using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    private int score;

    private void Start()
    {
        EnnemyManager.instance.onEnnemyDeath += EnnemyDeathHandler;
    }

    private void OnDisable()
    {
        EnnemyManager.instance.onEnnemyDeath -= EnnemyDeathHandler;
    }

    private void EnnemyDeathHandler()
    {
        score++;
        text.text = score.ToString();
    }
}
