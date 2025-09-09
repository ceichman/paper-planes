using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public TextMeshProUGUI _gameOverText;
    public GameObject _panel; // Background for text 
    public float timeUntilReset;
    public AudioSource winMusic; // win sound
    public AudioSource music; 
    void Start()
    {
        Singleton = this;
        if (_gameOverText == null) Debug.Log("null!");
        _panel.SetActive(false);
    }

    public void DisplayGameOver(int losingPlayer)
    {
        music.Stop();
        winMusic.Play();
        StartCoroutine(Display(losingPlayer));
    }
    
    IEnumerator Display(int losingPlayer)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("name: " + transform.name);
        Debug.Log("Game Manager method called with losingPlayer " + losingPlayer);
        if (losingPlayer == 2)
        {
            Debug.Log("here");
            _gameOverText.text = "Player 1 Wins!";
        }
        else
        {
            Debug.Log("Else");
            _gameOverText.text = "Player 2 Wins!";
        }
        Debug.Log("here again");
        _panel.SetActive(true);
        Invoke(nameof(RestartScene), timeUntilReset);
    }

    // to do: ui methods, ex game over ui and who wins

    void RestartScene()
    {
        Debug.Log("scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
