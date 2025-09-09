using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PowerUpSpeed : PowerUp
{

    public float timer;
    public float increase;

    private AudioSource speedUpAudio;


    protected override IEnumerator OnConsumed()
    {
        this.speedUpAudio = this.GetComponent<AudioSource>();
        float baseSpeed = player.GetComponent<PlaneMovement>()._thrustPower;
        Animator animator = player.GetComponent<Animator>();
        player.GetComponent<PlaneMovement>()._thrustPower = baseSpeed + increase;
        Debug.Log("speedup)");
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        player.GetComponent<Animator>().SetBool("PUSpeed", true);
        speedUpAudio.Play();


        yield return new WaitForSeconds(timer);
        Debug.Log("powerup over");
        player.GetComponent<PlaneMovement>()._thrustPower = baseSpeed;
        player.GetComponent<Animator>().SetBool("PUSpeed", false);
        Destroy(this.gameObject);

    }
}