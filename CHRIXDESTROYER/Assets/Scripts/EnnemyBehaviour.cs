using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    private float speed;
    private GameObject anim;

    public void Initialize(float newSpeed, GameObject newAnim)
    {
        speed = newSpeed;
        anim = newAnim;
    }

    private void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, CharPosition.instance.charTransform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            gameObject.SetActive(false);
            EnnemyManager.instance.EnnemyDeath();
            Pool.instance.GetItemFromPool(anim, transform.position, transform.rotation);
            collision.gameObject.SetActive(false);
        }
    }
}
