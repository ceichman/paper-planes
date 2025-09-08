using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDestroyable
{
    public UnityEvent OnDestroy;
    public bool canDamage; // Powerup, such as a shield, may want to toggle this on/off
    public int maxHealth;
    public int health;
    private int _playerNum;
    [SerializeField] private HealthBar _healthBar; 
    void Start()
    {

    }
    void Awake()
    {
        canDamage = true;
    }
    public void Damage(int damagePoints)
    {
        if (canDamage)
        {
            health -= damagePoints;
            UpdateHealthUI();
            Debug.Log("Damaged, new health: " + health);
            if (health <= 0)
            {
                OnDestroy.Invoke(); // Drag public methods into the inspector field of OnDestroy, and these will be automatically called
            }
        }
    }

    public void UpdateHealthUI()
    {
        _healthBar.SetHealth(health);
        // call HealthBar.SetHealth(float health)

    }
}
