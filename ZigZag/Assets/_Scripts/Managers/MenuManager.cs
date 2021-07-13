using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text InGameScoreText;
    [SerializeField] Text EndGameScoreText;
    [SerializeField] Text TopScoreText;

    Player _player;
    [SerializeField] GameObject EndMenuObject;
    void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        if (_player.IsDead)
        {
            EndMenu();
            SaveGame();
            _player.IsDead = false;
            TopScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        InGameScoreText.text = _player.Point.ToString();
        EndGameScoreText.text = _player.Point.ToString();
    }
    void EndMenu()
    {
        EndMenuObject.SetActive(true);
    }
    void SaveGame()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _player.Point);
        }
        else
        {
            if (PlayerPrefs.GetInt("HighScore") < _player.Point)
            {
                PlayerPrefs.SetInt("HighScore", _player.Point);
            }
        }
    }
}
