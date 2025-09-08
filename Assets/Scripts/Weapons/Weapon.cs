using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    protected int _playerNumber;

    abstract protected void Configure(GameObject shooter);

    protected void SetPlayerNumber(int playerNumber)
    {
        this._playerNumber = playerNumber;
    }

    [SerializeField] protected float damage;
    [SerializeField] public float cooldown;

    public void BeginConfigure(GameObject shooter, int playerNumber)
    {
        this._playerNumber = playerNumber;
        this.Configure(shooter);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerWeapons player = collision.gameObject.GetComponent<PlayerWeapons>();
        if (player)
        {
            if (player.playerNum == this._playerNumber) return;
            Camera.main.GetComponent<CameraController>().ShakeCamera(this.damage / 25f);
            // hit other player
            player.gameObject.GetComponent<PlayerHealth>().Damage(this.damage);
        }
        Destroy(this.gameObject);
    }

}