using System;
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
        leaderboard.data.Add(new DataItem(userInfo.name, userInfo.kills));
    }

    public void BackToMainMenu() => SceneManager.LoadScene("Main Menu");
}
