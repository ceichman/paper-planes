using System.Runtime.CompilerServices;
using UnityEngine;

public class Bomb : Weapon
{
    private float speed = 0f;
    [SerializeField] private float acceleration;
    public static float maximumSpeed = 100f;


    protected override void Configure(GameObject shooter)
    {

    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        speed += acceleration;
            
        if (this.speed > Bomb.maximumSpeed)
        {
            this.speed = Bomb.maximumSpeed;
            this.acceleration = 0;
        }
    }
}
