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
    public List<(string name, int kills, DateTime date)> Data { get; }
}
