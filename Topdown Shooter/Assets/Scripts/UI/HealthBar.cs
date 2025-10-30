using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    public Image healthFill;
    public Gradient gradient;
    public float maxHealth = 100;
    public float currentHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthFill.fillAmount = 1f;
    }

    void Update()
    {
        healthFill.fillAmount = (float)currentHealth / maxHealth;

        healthFill.color = gradient.Evaluate(healthFill.fillAmount);
    }

    
    public void Takedamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
             Debug.Log("Player is Dead");
        }
    }
}
