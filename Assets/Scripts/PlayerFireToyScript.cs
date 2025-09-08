using UnityEngine;
public class PlayerFireToyScript : MonoBehaviour
{
// this is just used to test PlayerDestroy; do not actually use this in game (damages self)
    [SerializeField] private int playerNum;
    private KeyCode _fire;
    private PlayerHealth _playerDestroy;
    [SerializeField] private int _damage;
    // Update is called once per frame

    void Start()
    {
<<<<<<< HEAD
        ConfigureControls();
        _playerDestroy = GetComponent<PlayerHealth>();
    }

    void ConfigureControls()
    {
        if (playerNum == 1)
        {
            _fire = KeyCode.Space;
        }
        else {
            _fire = KeyCode.DownArrow;
        }
=======
        // ConfigureControls();
>>>>>>> origin/main
    }

    void Update()
    {
        if (Input.GetKeyDown(_fire))
        {
            _playerDestroy.Damage(10); 
        }
    }
}
