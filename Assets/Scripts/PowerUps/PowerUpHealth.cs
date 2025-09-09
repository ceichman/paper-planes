using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class PowerUpHealth : PowerUp
{

    public float timer;
    public float increase;

    public AudioSource healAudio;

    protected override IEnumerator OnConsumed()
    {
        float baseHealth = player.GetComponent<PlayerHealth>().health;
        if (baseHealth == player.GetComponent<PlayerHealth>().maxHealth) yield return null;
        player.GetComponent<Animator>().SetBool("Healed", true);
        healAudio.Play();
        player.GetComponent<PlayerHealth>().health = baseHealth + increase;
        Debug.Log("heal");
        player.GetComponent<PlayerHealth>().UpdateHealthUI();
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        
        yield return new WaitForSeconds(timer);
        Debug.Log("powerup over");
        player.GetComponent<Animator>().SetBool("Healed", false);
         Destroy(this.gameObject);
    
    }
}
