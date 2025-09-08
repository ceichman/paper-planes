using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// For questions with this script, please talk to Dani 
[RequireComponent(typeof(Rigidbody2D))]
public class PlaneMovement : MonoBehaviour
{

    private Rigidbody2D _rb2d;
    [SerializeField] private int _playerNum; // either 1 or 2 
    [SerializeField] private float _thrustPower;
    [SerializeField] private KeyCode _thrust;
    [SerializeField] private KeyCode _rotateLeft;
    [SerializeField] private KeyCode _rotateRight;
    [SerializeField] private float _rotationSpeed; 
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
            _rb2d.MoveRotation(_rb2d.rotation + _rotationSpeed);
        }
        if (Input.GetKey(_rotateRight))
        { 
            _rb2d.MoveRotation(_rb2d.rotation - _rotationSpeed);
        }
    }
}
