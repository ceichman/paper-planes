using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// For questions with this script, please talk to Dani 
[RequireComponent(typeof(Rigidbody2D))]
public class PlaneMovement : MonoBehaviour
{

    private Rigidbody2D _rb2d;
    [SerializeField] public float _thrustPower;
    [SerializeField] private float _rotationTorque;
    [SerializeField] private float _backgroundTorqueStrength;
    [SerializeField] private float _wingAngle = 10;
    [SerializeField] private KeyCode _thrust;
    [SerializeField] private KeyCode _rotateLeft;
    [SerializeField] private KeyCode _rotateRight;
    [SerializeField] private float wallKnockbackStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // NOTE: If drag doesn't feel good, what we can do is set it to 0 by default but when the player doesn't
        // touch any key input, then we can set drag to something like 2.5f. 
        if (Input.GetKey(_thrust))
        {
            Debug.Log("Thrust");
            _rb2d.AddForce(transform.up * _thrustPower);
        }
        if (Input.GetKey(_rotateLeft))
        {
            _rb2d.AddTorque(_rotationTorque);
        }
        if (Input.GetKey(_rotateRight))
        {
            _rb2d.AddTorque(-_rotationTorque);
        }
        // add resetting rotation ("background torque") towards horizontal direction
        float currentRotation = this.transform.rotation.eulerAngles.z;
        float angularDistanceToHorizontal = (currentRotation > 180) ? 270 - currentRotation + _wingAngle : 90 - currentRotation - _wingAngle;
        _rb2d.AddTorque(_backgroundTorqueStrength * angularDistanceToHorizontal);

        this.GetComponent<SpriteRenderer>().flipX = currentRotation < 180 ? true : false;

        // more drag at high angles of attack (from 0 to 1)
        _rb2d.linearDamping = Mathf.Clamp(0.3f, 1.0f, Mathf.Abs(angularDistanceToHorizontal) / 90.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 force = contact.normalImpulse * contact.normal * this.wallKnockbackStrength;
            this._rb2d.AddForce(force);
        }
    }

}
