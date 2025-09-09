using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class PlayerHealth : MonoBehaviour, IDestroyable
{
    public UnityEvent OnDestroy;
    public bool canDamage; // Powerup, such as a shield, may want to toggle this on/off
    public float maxHealth;
    public float health;

    private AudioSource audioSource;

    [SerializeField] public AudioClip damageSound;
    public int _playerNum;

    private Animator animator;
    [SerializeField] private HealthBar _healthBar;

    void Awake()
    {
        canDamage = true;
    }

    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    public void Damage(float damagePoints)
    {
        if (canDamage)
        {
            health -= damagePoints;
            UpdateHealthUI();
            StartCoroutine(DamageAnim());
            Debug.Log("Damaged, new health: " + health);
            if (health <= 0)
            {
                Debug.Log("Calling game over");
                GameManager.Singleton.DisplayGameOver(_playerNum);
                this.OnDestroy.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator DamageAnim()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Damaged", true);
        this.audioSource.PlayOneShot(this.damageSound);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Damaged", false);


    }
    public void UpdateHealthUI()
    {
        if (health < 0) health = 0;
        _healthBar.SetHealth(health);
    }
}
