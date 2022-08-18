using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetAI : MonoBehaviour
{
    public Text healthText;
    public Slider healthBar;
    public Image bar;
    public int health;
    public int maxHealth = 100;
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = "hp: " + health;
        healthBar.value = health;
        bar.color = Color.Lerp(Color.red, Color.green, (float) health / maxHealth);
        if(health == 0)
        {
            bar.gameObject.SetActive(false);
        }
        else
        {
            bar.gameObject.SetActive(true);
        }
    }
  

    public void Damage(int damageAmmount)
    {
        if (health - damageAmmount < 0)
        {
            health = 0;
        }
        else
        {
            health -= damageAmmount;
        }

        UpdateUI();
    }


    public void Heal(int healAmmount)
    {
        if (health + healAmmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmmount;
        }

        UpdateUI();
    }



}
