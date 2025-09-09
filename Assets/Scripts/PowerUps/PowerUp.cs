using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public abstract class PowerUp : MonoBehaviour
{
    private float currentRotationZ;
    [SerializeField] private float rotationSpeed;
    protected GameObject player;
    protected abstract IEnumerator OnConsumed();

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide with powerup");
        if (collision.gameObject.tag == "Player")
        {
            this.player = collision.gameObject;
            StartCoroutine(OnConsumed());
        }
    }

    protected IEnumerator RotateWhileFalling()
    {
        this.currentRotationZ += Time.deltaTime * rotationSpeed;
        this.transform.rotation = Quaternion.AngleAxis(currentRotationZ, Vector3.forward);
        yield return null;
    }
    void Start()
    {
        StartCoroutine(this.RotateWhileFalling());
    }
}