using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDestroyable
{
    public UnityEvent OnDestroy;
    public bool canDamage; // Powerup, such as a shield, may want to toggle this on/off
    public float maxHealth;
    public float health;
    public int _playerNum;
    [SerializeField] private HealthBar _healthBar; 

    void Awake()
    {
        canDamage = true;
    }
    public void Damage(float damagePoints)
    {
        if (canDamage)
        {
            health -= damagePoints;
            UpdateHealthUI();
            Debug.Log("Damaged, new health: " + health);
            if (health <= 0)
            {
                Debug.Log("Calling game over");
                GameManager.Singleton.DisplayGameOver(_playerNum);
                Destroy(this.gameObject);
            }
        }
    }

    public void UpdateHealthUI()
    {
        if (health < 0) health = 0; 
        _healthBar.SetHealth(health);
    }
}
