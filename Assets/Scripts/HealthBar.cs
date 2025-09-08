using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    private float health;
    public float maxWidth;
    public float Height;
    public Transform followTransform;
    public int yOffset; 
    public RectTransform healthTransform;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        PlayerHealth plh = followTransform.GetComponent<PlayerHealth>();
        maxHealth = plh.maxHealth;
        health = plh.health;
        Debug.Log("health: " + health);
        Debug.Log("maxHealth: " + maxHealth);

    }
    public void SetHealth(float newHealth)
    {
        // How this works is to take the Health RectTransform and 
        // edit the width based on the health / maxHealth
        health = newHealth;
        float newWidth = (health / maxHealth) * maxWidth;
        healthTransform.sizeDelta = new Vector2(newWidth, Height);

    }

    public void FixedUpdate()
    {
        _rectTransform.position = followTransform.position + new Vector3(0, yOffset);
    }

    
}
