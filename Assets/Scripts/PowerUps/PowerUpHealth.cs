using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class PowerUpHealth : PowerUp
{

    public float timer;
    public float healingEffect;

    public AudioSource healAudio;

    protected override IEnumerator OnConsumed()
    {
        PlayerHealth healthScript = player.GetComponent<PlayerHealth>();
        float newHealth = Mathf.Min(healthScript.health + this.healingEffect, healthScript.maxHealth);
        player.GetComponent<Animator>().SetBool("Healed", true);
        healAudio.Play();
        healthScript.health = newHealth;
        Debug.Log("heal");
        healthScript.UpdateHealthUI();
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        
        yield return new WaitForSeconds(timer);
        Debug.Log("powerup over");
        player.GetComponent<Animator>().SetBool("Healed", false);
        Destroy(this.gameObject);
    
    }
}
