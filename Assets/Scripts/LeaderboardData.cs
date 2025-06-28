using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object holding data related to leaderboard
/// </summary>
[CreateAssetMenu(menuName = "LeaderboardData")]
public class LeaderboardData : ScriptableObject
{
    /// <summary>
    /// Leaderboard data
    /// </summary>
    public List<DataItem> data = new();
}

[Serializable]
public class DataItem
{
    public string name;
    public int kills;
    public DateTime date;
    
    public DataItem(string name, int kills)
    {
        this.name = name;
        this.kills = kills;
        date = DateTime.Now;
    }
}
