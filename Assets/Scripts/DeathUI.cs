using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    // setup kill counter to show the right values
    [SerializeField] private TMP_Text killCounter;
    [SerializeField] private TMP_Text nameText;
    
    private void OnEnable()
    {
        nameText.text = SessionData.Name;
        killCounter.text = SessionData.Kills.ToString();
        Leaderboard.Add(SessionData.Name, SessionData.Kills);
        Leaderboard.Save();
    }

    public void BackToMainMenu() => SceneManager.LoadScene("Main Menu");
}
