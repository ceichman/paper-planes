using UnityEngine;

public class ToggleDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KeyCode toggleKey;
    public GameObject objToToggle;
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            objToToggle.SetActive(!objToToggle.activeInHierarchy);
        }
    }
}
