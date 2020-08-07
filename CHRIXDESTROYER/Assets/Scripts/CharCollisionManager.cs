using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollisionManager : MonoBehaviour
{
    public static CharCollisionManager instance;
    public event Action onHit;
    [SerializeField] private GameObject anim;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            Pool.instance.GetItemFromPool(anim, transform.position, transform.rotation);
            collision.gameObject.SetActive(false);
            onHit?.Invoke();
        }
    }
}
