using UnityEngine;

public class CameraController : MonoBehaviour

{
    public GameObject player1;
    public GameObject player2;

    public float cameraScaleFactor = 1.0f;
    public float maxCameraSize = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player1 || !player2) return;
        Vector2 midpointBetweenPlayers = (((player1.transform.position - player2.transform.position) / 2) + player2.transform.position);
        this.transform.position = new Vector3(midpointBetweenPlayers.x, midpointBetweenPlayers.y, -10);
        float distanceBetweenPlayers = Vector2.Distance(player1.transform.position, player2.transform.position);
        Camera cam = this.GetComponent<Camera>();
        cam.orthographicSize = Mathf.Min(distanceBetweenPlayers * cameraScaleFactor, maxCameraSize);
    }
}
