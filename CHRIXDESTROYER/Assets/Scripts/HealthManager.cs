using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro tmp;
    [SerializeField] private TextMeshPro deathText;
    [SerializeField] private GameObject endText, player, explosion;
    [SerializeField] private List<GameObject> stuffToDeactivate;

    private void Start()
    {
        CharCollisionManager.instance.onHit += OnHitHandler;
        tmp.text = health.ToString();
    }

    private void OnHitHandler()
    {
        health--;
        tmp.text = health.ToString();
        Pool.instance.GetItemFromPool(explosion, player.transform.position, transform.rotation);
        if(health <= 0)
        {
            StartCoroutine(StartAgain());
        }
    }

    private IEnumerator StartAgain()
    {
        foreach (var stuff in stuffToDeactivate)
        {
            stuff.SetActive(false);
        }
        endText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
