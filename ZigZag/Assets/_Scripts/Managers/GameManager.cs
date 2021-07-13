using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Player _player;
    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }
    public void MainMenu()
    {
        Invoke("Main", 1);
    }
    public void RestartGame()
    {
        Invoke("Restart", 1);
    }
    void Main()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}