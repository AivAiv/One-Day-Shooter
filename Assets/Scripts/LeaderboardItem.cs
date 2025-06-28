using System;
using TMPro;
using UnityEngine;
public class LeaderboardItem : MonoBehaviour
{
    [SerializeField] private TMP_Text username;
    [SerializeField] private TMP_Text kill;
    [SerializeField] private TMP_Text date;
    
    public void SetData(DataItem item)
    {
        username.text = item.name;
        kill.text = item.kills.ToString();
        date.text = item.date.ToString("MM/dd/yyyy");
    }
}
