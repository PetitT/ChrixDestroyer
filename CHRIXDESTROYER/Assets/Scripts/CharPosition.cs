using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPosition : MonoBehaviour
{
    public static CharPosition instance;
    private Transform position;

    public Transform charTransform
    {
        get { return position; }
        private set { position = value; }
    }


    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        position = transform;
    }
}
