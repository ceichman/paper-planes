using System.Collections;
using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public float fadeSpeedInSeconds;
    public float fadeDelay; 
    public TMP_Text textMesh;
    void Start()
    {
        Invoke(nameof(BeginFade), fadeDelay);
    }

    void BeginFade()
    {
        StartCoroutine(Fade());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade()
    {
        Color c = textMesh.color;
        // make transparent
        while (c.a > 0f)
        {
            c.a -= Time.deltaTime / fadeSpeedInSeconds; 
            textMesh.color = c;
            yield return null;
        }

        c.a = 0f;
        textMesh.color = c;
    }
}
