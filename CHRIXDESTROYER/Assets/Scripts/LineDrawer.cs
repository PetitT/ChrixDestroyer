using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform body;
    [SerializeField] private Transform target;

    private void Update()
    {
        line.SetPosition(0, body.transform.position);
        line.SetPosition(1, target.transform.position);
    }
}
