using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDestroy : MonoBehaviour, IDestroyable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent OnDestroy; 
    public bool canDamage; // Powerup, such as a shield, may want to toggle this on/off
    [SerializeField] private int health;

    void Awake()
    {
        canDamage = true;
    }
    public void Damage(int damagePoints)
    {
        if (canDamage)
        {
            health -= damagePoints;
            if (health <= 0)
            {
                OnDestroy.Invoke();
            }
        }
    }
}
