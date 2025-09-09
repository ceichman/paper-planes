using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUnfold : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;
    public float grav;
    private bool canUnfold = true;
    //public float foldedTime;
    public float cooldown;

    public KeyCode unfoldKey;
    public AudioSource unfoldAudio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Unfolded", false);


    }
    void Update()
    {

        //keycode unfold
        if (Input.GetKey(unfoldKey) && canUnfold)
        {
            Unfold();
            //StartCoroutine(ResetToPlane());
        }

        if (Input.GetKeyUp(unfoldKey))
        {
            StartCoroutine(ResetToPlane());

        }
    }



    void Unfold()
    {
        rb.gravityScale = grav;
        Debug.Log("gravity added");
        canUnfold = false;
        Debug.Log("cant unfold now");
        //pull health/damageable and disable
        GetComponent<PlayerHealth>().canDamage = false;
        //disable movement
        GetComponent<PlaneMovement>().enabled = false;
        animator.SetBool("Unfolded", true);
        Debug.Log("animation input");
        unfoldAudio.Play();
    
    }

    IEnumerator ResetToPlane()
    {
        //yield return new WaitForSeconds(foldedTime);
        
    
            animator.SetBool("Unfolded", false);
            rb.gravityScale = 0.3F;
            //enable movement
            GetComponent<PlaneMovement>().enabled = true;
            //enable health/damageable
            GetComponent<PlayerHealth>().canDamage = true;
            Debug.Log("plane is resetting");
    

        yield return new WaitForSeconds(cooldown);
        canUnfold = true;
        Debug.Log("plane can unf0ld again");

    }

}
