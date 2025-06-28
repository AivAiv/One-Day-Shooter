/// <summary>
/// A pure static class holding information about the current run
/// </summary>
public static class SessionData
{
    /// <summary>
    /// The name of the current user
    /// </summary>
    public static string Name { get; set; }
    
    /// <summary>
    /// The kills done by the current user
    /// </summary>
    public static int Kills { get; set; }
}