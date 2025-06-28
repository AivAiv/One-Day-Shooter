using UnityEngine;

/// <summary>
/// The data related to the current user
/// </summary>
[CreateAssetMenu(menuName = "User Info")]
public class UserInfo : ScriptableObject
{
    /// <summary>
    /// The name of the current user
    /// </summary>
    public new string name;

    /// <summary>
    /// The kills done by the current user
    /// </summary>
    public int kills;
}
