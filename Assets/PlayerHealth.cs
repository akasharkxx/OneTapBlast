using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI shieldText;
    [SerializeField] private int maxHealth, maxShield;

    private int currentHealth, currentShield;
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
