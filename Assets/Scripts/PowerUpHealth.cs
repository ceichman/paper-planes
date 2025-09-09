using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class PowerUpHealth : MonoBehaviour
{

    private GameObject player;
    private float baseHealth;
    public float timer;
    public float increase;

    public AudioSource healAudio;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
        player = collision.gameObject;
        baseHealth = player.GetComponent<PlayerHealth>().health;

        if (baseHealth < player.GetComponent<PlayerHealth>().maxHealth)
        {
            StartCoroutine(Heal());
        }
    }
     }




    IEnumerator Heal()
    {


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
