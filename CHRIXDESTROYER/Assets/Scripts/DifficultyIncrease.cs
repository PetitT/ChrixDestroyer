using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyIncrease : MonoBehaviour
{
    public static DifficultyIncrease instance;
    public event Action onDifficultyIncrease;
    [SerializeField] private float timeBeforeDifficultyIncrease;
    private float remainingTime;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        remainingTime = timeBeforeDifficultyIncrease;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            onDifficultyIncrease?.Invoke();
            remainingTime = timeBeforeDifficultyIncrease;
        }
    }
}
