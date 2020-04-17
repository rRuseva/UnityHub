using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
   // public Gradient gradient;
  //  public Image fill; 
    public void SetHealth(int health) {
        slider.value = health;
       // fill.color = gradient.Evaluate(slider.normalizedValue );
    }

    public void SetMaxHealth(int maxHealth) {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
     //   gradient.Evaluate(1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
