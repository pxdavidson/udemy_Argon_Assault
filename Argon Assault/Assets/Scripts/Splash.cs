using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    LevelLoader levelLoader;

    // Use this for initialization
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
    }

    void StartGame()
    {
        if (Input.anyKeyDown)
        {
            levelLoader.LoadFirstLevel();
        }
    }
}
