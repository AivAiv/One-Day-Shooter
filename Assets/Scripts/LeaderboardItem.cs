using System;
using TMPro;
using UnityEngine;
public class LeaderboardItem : MonoBehaviour
{
    [SerializeField] private TMP_Text username;
    [SerializeField] private TMP_Text kill;
    [SerializeField] private TMP_Text date;
    
    public void SetData((string name, int kills, DateTime date) data)
    {
        username.text = data.name;
        kill.text = data.kills.ToString();
        date.text = data.date.ToString("dd/MM/yyyy");
    }
}
