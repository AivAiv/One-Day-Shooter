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
    [SerializeField] private LeaderboardData leaderboard;
    
    private void OnEnable()
    {
        nameText.text = SessionData.Name;
        killCounter.text = SessionData.Kills.ToString();
        leaderboard.Data.Sort((a, b) => b.kills.CompareTo(a.kills));
        if (leaderboard.Data.Count >= 10)
        {
            if (leaderboard.Data[9].kills > SessionData.Kills) return; 
            leaderboard.Data.Remove(leaderboard.Data.Last());
        }
        leaderboard.Data.Add(new DataItem(SessionData.Name, SessionData.Kills));
    }

    public void BackToMainMenu() => SceneManager.LoadScene("Main Menu");
}
