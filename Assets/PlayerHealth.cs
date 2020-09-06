using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private int maxHealth;

    private int currentHealth;
    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;    
    }

    private void Update()
    {
        healthText.text = currentHealth.ToString();   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            isDead = true;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public bool GetisDead()
    {
        return isDead;
    }
}
