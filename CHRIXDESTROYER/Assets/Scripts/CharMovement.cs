using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [Header("Body")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform body;

    [Header("Clamp")]
    [SerializeField] private Transform minXminY;
    [SerializeField] private Transform maxXmaxY;

    [Header("Stats")]
    [SerializeField] private float targetSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistanceFromTarget;

    private void Update()
    {
        Move();
        FollowTarget();
        ClampPosition();
    }


    private void Move()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(X, Y);
        target.transform.Translate(movement * targetSpeed * Time.deltaTime);
    }

    private void FollowTarget()
    {
        body.transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - body.transform.position);

        //if (Vector2.Distance(target.position, body.position) > maxDistanceFromTarget)
        if (Input.GetButton("Fire1"))
        {
            body.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

    private void ClampPosition()
    {
        float X = target.transform.position.x;
        float Y = target.transform.position.y;

        if (X > maxXmaxY.transform.position.x)
            X = maxXmaxY.transform.position.x;

        if (Y > maxXmaxY.transform.position.y)
            Y = maxXmaxY.transform.position.y;

        if (X < minXminY.transform.position.x)
            X = minXminY.transform.position.x;

        if (Y < minXminY.transform.position.y)
            Y = minXminY.transform.position.y;

        target.transform.position = new Vector2(X, Y);
    }
}
