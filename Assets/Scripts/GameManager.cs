using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    void Start()
    {
        Singleton = this;
    }

    // to do: ui methods, ex game over ui and who wins
}
