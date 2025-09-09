using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
// this is just used to test PlayerDestroy; do not actually use this in game (damages self)
    public int playerNum;
    [SerializeField] private KeyCode _fire;
    public GameObject currentWeapon;
    private AudioSource weaponAudio;

    private float cooldownTimer = 0;
    // Update is called once per frame

    void Start()
    {
        this.weaponAudio = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(_fire) && (cooldownTimer == 0))
        {
            GameObject weaponObject = Instantiate(this.currentWeapon, this.transform.position, this.transform.rotation);
            Weapon currentWeapon = weaponObject.GetComponent<Weapon>();
            currentWeapon.BeginConfigure(this.gameObject, this.playerNum);
            cooldownTimer = currentWeapon.GetComponent<Weapon>().cooldown;
            weaponAudio.PlayOneShot(currentWeapon.shootingSound);
        }
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            cooldownTimer = 0;
        }
    }
}
