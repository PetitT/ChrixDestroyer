using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private float speed;

    public void Initialize(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
    }
}
