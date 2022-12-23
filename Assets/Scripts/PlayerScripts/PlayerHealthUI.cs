using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : PlayerHealth
{
    private float lerpTimer;
    [SerializeField]private Image frontHealthBar;
    [SerializeField]private Image backHealthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    
    [SerializeField]private float chipSpeed = 2f;

    
    [Header("Damage Overlay")]
    [SerializeField] private Image overlay;
    [SerializeField] private float duration;
    [SerializeField] private float fadeSpeed;
    private float durationTimer;
    
    // Start is called before the first frame update
    void Start()
    {
    
        overlay.color = new Color(overlay.color.r,overlay.color.g,overlay.color.b, 0);
       
    }

    void Update()
    {
        UpdateHealthUI();
        if (overlay.color.a > 0)
        {
            if (health < 30)
                return;

            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;

                overlay.color = new Color(overlay.color.r,overlay.color.g,overlay.color.b, tempAlpha);
            }
        }
    }
    
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = GetHealthFraction();

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
             
            backHealthBar.fillAmount = Mathf.Lerp(fillB,hFraction,percentComplete());

        } 
        
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;  
            lerpTimer += Time.deltaTime;
             
            frontHealthBar.fillAmount = Mathf.Lerp(fillF,hFraction,percentComplete());

        }
        
    }

    private float percentComplete()
    {
        return MathF.Pow(lerpTimer / chipSpeed, 2);
    }

}
