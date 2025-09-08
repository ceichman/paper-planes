using UnityEngine;

public class Missile : Weapon
{

    [SerializeField] private float acceleration;
    private float speed = 0;
    [SerializeField] private float maximumSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void FixedUpdate()
    {
        this.transform.position += new Vector3(
            Mathf.Sin(this.transform.rotation.eulerAngles.z) * speed,
            Mathf.Cos(this.transform.rotation.eulerAngles.z) * speed,
            0
        );
        speed += acceleration;
            
        if (this.speed > maximumSpeed)
        {
            this.speed = maximumSpeed;
            this.acceleration = 0;
        }
    }
}
