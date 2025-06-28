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
    [SerializeField] private UserInfo userInfo;
    [SerializeField] private LeaderboardData leaderboard;
    
    private void OnEnable()
    {
        nameText.text = userInfo.name;
        killCounter.text = userInfo.kills.ToString();
        leaderboard.Data.Sort((a, b) => b.kills.CompareTo(a.kills));
        if (leaderboard.Data[9].kills > userInfo.kills) return;
        if (leaderboard.Data.Count >= 10) leaderboard.Data.Remove(leaderboard.Data.Last());
        leaderboard.Data.Add(new DataItem(userInfo.name, userInfo.kills));
    }

    public void BackToMainMenu() => SceneManager.LoadScene("Main Menu");
}
