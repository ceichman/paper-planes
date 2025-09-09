using UnityEngine;
using System.Collections;

public class PowerUpWeapon : PowerUp
{
    [SerializeField] private GameObject weaponPrefab;
    // Update is called once per frame
    void Update()
    {

    }

    protected override IEnumerator OnConsumed()
    {
        player.GetComponent<PlayerWeapons>().currentWeapon = weaponPrefab;
        this.GetComponent<AudioSource>().Play();
        yield return null;
    }
}
