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
    public List<DataItem> Data = new();
}

[Serializable]
public class DataItem
{
    public string name;
    public int kills;
    public long timestamp;
    
    public DataItem(string name, int kills)
    {
        this.name = name;
        this.kills = kills;
        timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    
    public DateTime GetDate() => DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
}
