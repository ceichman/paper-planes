using System;
using UnityEngine;

public class Missile : Weapon
{

    [SerializeField] private float acceleration;
    private float speed = 20;
    public static float maximumSpeed = 100f;
    public static float inheritedVelocityScaling = 10f;

    public override void Configure(GameObject shooter)
    {
        Vector2 shooterVelocity = shooter.GetComponent<Rigidbody2D>().linearVelocity.normalized;
        this.speed = Missile.inheritedVelocityScaling * Vector2.Dot(shooterVelocity, shooter.transform.up);
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.fixedDeltaTime * speed;
        Debug.DrawLine(this.transform.position, (this.transform.position - this.transform.up) * speed * 5.0f, Color.red);
        speed += acceleration;
            
        if (this.speed > maximumSpeed)
        {
            this.speed = maximumSpeed;
            this.acceleration = 0;
        }
    }
}
