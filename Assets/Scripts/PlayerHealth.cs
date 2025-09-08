using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDestroyable
{
    public UnityEvent OnDestroy;
    public bool canDamage; // Powerup, such as a shield, may want to toggle this on/off
    public int maxHealth;
    public int health;
    public int _playerNum;
    [SerializeField] private HealthBar _healthBar; 
    void Start()
    {

    }
    void Awake()
    {
        canDamage = true;
    }

    void Update()
    {
        TestDamage();
        
    }

    void TestDamage()
    { // for debug purposes only; TODO: REMOVE when not needed.
        if (Input.GetKeyDown(KeyCode.T)) {
            Damage(10);
        }
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
                Debug.Log("Calling game over");
                GameManager.Singleton.DisplayGameOver(_playerNum);
            }
        }
    }

    public void UpdateHealthUI()
    {
        if (health < 0) health = 0; 
        _healthBar.SetHealth(health);
    }
}
