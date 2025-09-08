using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public GameObject player1;
    public GameObject player2;

    public float cameraScaleFactor = 1.0f;
    public float maxCameraSize = 10f;

    [SerializeField] float shakeFrequency = 25f;
    [SerializeField] float shakeStrength = 0.5f;
    [SerializeField] float shakeRecoverySpeed = 1.5f;
    [SerializeField] float transitionSpeed = 0.3f;
    private float trauma = 0f;
    private float noiseSeed;

    private void Awake()
    {
        noiseSeed = UnityEngine.Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 && player2)
        {
            Vector2 midpointBetweenPlayers = (((player1.transform.position - player2.transform.position) / 2) + player2.transform.position);
            this.transform.position = new Vector3(midpointBetweenPlayers.x, midpointBetweenPlayers.y, -10);
            float distanceBetweenPlayers = Vector2.Distance(player1.transform.position, player2.transform.position);
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = Mathf.Min(distanceBetweenPlayers * cameraScaleFactor, maxCameraSize);
        }
        else if (player1 || player2)
        {
            // if only one player alive, transition over to that player
            Transform player = player1 ? player1.transform : player2.transform;
            Vector2 toRemainingPlayer = (player.position - this.transform.position) * this.transitionSpeed;
            this.transform.position += new Vector3(toRemainingPlayer.x, toRemainingPlayer.y, 0);
        }

        this.CalculateShake();

    }

    private void CalculateShake()
    {
        float shake = Mathf.Pow(trauma, 2);
        this.transform.position += new Vector3(
            Mathf.PerlinNoise(noiseSeed, Time.time * this.shakeFrequency) * 2 - 1,
            Mathf.PerlinNoise(noiseSeed + 1, Time.time * this.shakeFrequency) * 2 - 1,
            -10f
        ) * shake * this.shakeStrength;

        this.trauma = Mathf.Clamp01(this.trauma - shakeRecoverySpeed * Time.deltaTime);
    }

    public void ShakeCamera(float stress)
    {
        this.trauma = Mathf.Clamp01(trauma + stress);
    }
}
