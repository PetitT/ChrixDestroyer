using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    public static EnnemyManager instance;
    public event Action onEnnemyDeath;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void EnnemyDeath()
    {
        onEnnemyDeath?.Invoke();
    }
}
