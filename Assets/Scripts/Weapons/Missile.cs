using System;
using UnityEngine;

public class Missile : Weapon
{

    [SerializeField] private float acceleration;
    private float speed = 20;
    public static float maximumSpeed = 100f;
    public static float inheritedVelocityScaling = 10f;

    protected override void Configure(GameObject shooter)
    {
        Vector2 shooterVelocity = shooter.GetComponent<Rigidbody2D>().linearVelocity.normalized;
        this.speed = Missile.inheritedVelocityScaling * Vector2.Dot(shooterVelocity, shooter.transform.up);
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        speed += acceleration;
            
        if (this.speed > Missile.maximumSpeed)
        {
            this.speed = Missile.maximumSpeed;
            this.acceleration = 0;
        }
    }
}
