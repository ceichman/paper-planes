using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
