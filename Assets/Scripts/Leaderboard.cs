using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Static class that enable leaderboard storage. It holds 10 elements at most.
/// </summary>
public static class Leaderboard
{
    private static readonly string _path = Path.Combine(Application.persistentDataPath, "leaderboard.json");
    private static List<(string name, int kills, DateTime date)> _data;
    
    /// <summary>
    /// Adds a new item to the save
    /// </summary>
    /// <param name="name">the name of the user</param>
    /// <param name="kills">kills done by the user</param>
    public static void Add(string name, int kills)
    {
        if (_data == null) Load();
        if (_data.Count >= 10)
        {
            if (_data[9].kills > kills) return;
            _data.RemoveAt(9);
        }
        _data.Add((name, kills, DateTime.Now));
        _data.Sort((a, b) => b.kills.CompareTo(a.kills));
    }

    /// <summary>
    /// Returns leaderboard
    /// </summary>
    public static List<(string name, int kills, DateTime date)> Get()
    {
        if (_data == null) Load();
        return _data;
    }

    /// <summary>
    /// Store the current changes to the file
    /// </summary>
    public static void Save()
    {
        if (_data == null) return;
        var wrapper = new EntryListWrapper();
        foreach (var (name, kills, date) in _data)
        {
            wrapper.entries.Add(new Entry
            {
                name = name,
                kills = kills,
                date = date.ToString("o") // ISO 8601
            });
        }
        var json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(_path, json);
    }

    private static void Load()
    {
        _data = new List<(string name, int kills, DateTime date)>();
        if (!File.Exists(_path)) return;
        var json = File.ReadAllText(_path);
        var wrapper = JsonUtility.FromJson<EntryListWrapper>(json);
        if (wrapper?.entries == null) return;
        foreach (var entry in wrapper.entries)
        {
            if (DateTime.TryParse(entry.date, out DateTime parsedDate))
            {
                _data.Add((entry.name, entry.kills, parsedDate));
            }
        }
    }
    
    [Serializable]
    private class Entry
    {
        public string name;
        public int kills;
        public string date;
    }

    [Serializable]
    private class EntryListWrapper
    {
        public List<Entry> entries = new();
    }
}