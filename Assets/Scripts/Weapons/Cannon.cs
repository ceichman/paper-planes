using UnityEngine;

public class Cannon : Weapon
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 0.4f;
    [SerializeField] private float spread = 8;  // number of degrees off center to make each bullet

    protected override void Configure(GameObject shooter)
    {
        // make two more of myself on either side
        Quaternion leftRotation = Quaternion.AngleAxis(this.transform.rotation.eulerAngles.z - spread, Vector3.forward);
        Quaternion rightRotation = Quaternion.AngleAxis(this.transform.rotation.eulerAngles.z + spread, Vector3.forward);

        GameObject leftBullet = Instantiate(this.gameObject, this.transform.position, leftRotation);
        GameObject rightBullet = Instantiate(this.gameObject, this.transform.position, rightRotation);

        leftBullet.GetComponent<Cannon>()._playerNumber = this._playerNumber;
        rightBullet.GetComponent<Cannon>()._playerNumber = this._playerNumber;
    }

    void Update()
    {
        if (this.lifetime <= 0)
        {
            Destroy(this.gameObject);
            return;
        }

        lifetime -= Time.deltaTime;
        this.transform.position += transform.up * this.speed * Time.deltaTime;
    }

}

