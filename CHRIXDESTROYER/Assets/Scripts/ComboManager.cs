using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private TextMeshPro number;
    [SerializeField] private float comboTime;
    [SerializeField] private List<int> scores;
    [SerializeField] private List<string> texts;

    private int currentCombo = 0;
    private float remainingComboTime;


    private void Start()
    {
        EnnemyManager.instance.onEnnemyDeath += EnnemyDeathHandler;
    }

    private void OnDisable()
    {
        EnnemyManager.instance.onEnnemyDeath -= EnnemyDeathHandler;
    }

    private void EnnemyDeathHandler()
    {
        remainingComboTime = comboTime;
        currentCombo++;
        UpdateComboText();
        UpdateComboNumber();
    }

    private void UpdateComboNumber()
    {
        number.text = "x" + currentCombo.ToString();
    }

    private void UpdateComboText()
    {
        if (currentCombo > scores[scores.Count - 1])
            text.text = texts[scores.Count - 1];
        else if (currentCombo < scores[0])
            text.text = "";
        else
        {
            for (int i = 0; i < scores.Count; i++)
            {
                if (currentCombo > scores[i] && currentCombo < scores[i + 1])
                {
                    text.text = texts[i];
                    return;
                }
            }
        }
    }

    private void Update()
    {
        UpdateSlider();
        ComboCoolDown();
    }

    private void ComboCoolDown()
    {
        remainingComboTime -= Time.deltaTime;
        if (remainingComboTime < 0)
        {
            currentCombo = 0;
            UpdateComboNumber();
            UpdateComboText();
        }
    }

    private void UpdateSlider()
    {
        float sliderValue = remainingComboTime / comboTime;
        slider.value = sliderValue;
    }
}
