using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro tmp;
    [SerializeField] private GameObject endText, player, target, explosion;

    private void Start()
    {
        CharCollisionManager.instance.onHit += OnHitHandler;
        tmp.text = health.ToString();
    }

    private void OnHitHandler()
    {
        health--;
        tmp.text = health.ToString();
        if(health <= 0)
        {
            StartCoroutine(StartAgain());
        }
    }

    private IEnumerator StartAgain()
    {
        Pool.instance.GetItemFromPool(explosion, player.transform.position, transform.rotation);
        player.SetActive(false);
        target.SetActive(false);
        endText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
