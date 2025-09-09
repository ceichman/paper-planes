using UnityEngine;

public class BackgroundPicker : MonoBehaviour
{
    public GameObject[] backgrounds;
    public Vector3 spawnPosition = new Vector3(0, 0, -20);

    void Start()
    {
        if (backgrounds.Length == 0) return;
        int index = Random.Range(0, backgrounds.Length);
        GameObject bg = Instantiate(backgrounds[index], Vector3.zero, Quaternion.identity);
        bg.transform.position = spawnPosition;
    }
}