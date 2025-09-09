using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PowerUpSpeed : MonoBehaviour
{

    public float timer;
    private GameObject player;
    private float baseSpeed;
    private Animator animator;
    public float increase;

    public AudioSource speedUpAudio;

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            baseSpeed = player.GetComponent<PlaneMovement>()._thrustPower;
            animator = player.GetComponent<Animator>();
            StartCoroutine(SpeedUp());

        }
    }



    IEnumerator SpeedUp()
    {

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