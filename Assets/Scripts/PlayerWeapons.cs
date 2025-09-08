using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
// this is just used to test PlayerDestroy; do not actually use this in game (damages self)
    [SerializeField] private int playerNum;
    [SerializeField] private KeyCode _fire;
    public GameObject currentWeapon;
    // Update is called once per frame

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(_fire))
        {
            Instantiate(this.currentWeapon, this.transform.position, this.transform.rotation);
        }
    }
}
