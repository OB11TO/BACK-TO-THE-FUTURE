using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public GameObject replayObject;
    public GameObject winText;
    public GameObject loseText;
    public GameObject tapText;

    bool isWon = false;
    bool isGameOver = false;

    public Player player;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
        replayObject.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    public void Play()
    {
        replayObject.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void ShowReplayScreen()
    {
        replayObject.SetActive(true);
    }

    public void WinScreen()
    {
        winText.SetActive(true);
    }

    public void GameOverScreen()
    {
        loseText.SetActive(true);
    }

    public void ActivateTapping(bool enable)
    {
        tapText.SetActive(enable);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
