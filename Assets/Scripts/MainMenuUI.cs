using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The script handling the main menu scene
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    
    private void Start()
    {
        if (string.IsNullOrEmpty(SessionData.Name)) return;
        nameInputField.text = SessionData.Name;
    }
    
    /// <summary>
    /// The callback that the start button calls when clicked
    /// </summary>
    public void StartGame()
    {
        if (nameInputField == null || nameInputField.text == string.Empty)
        {
            //TODO improve this shit
            return;
        }

        SessionData.Name = nameInputField.text;
        SceneManager.LoadScene("Game");
    }
    
    /// <summary>
    /// The callback that the leaderboard button calls when clicked
    /// </summary>
    public void GoToLeaderboard()
    {
        SessionData.Name = nameInputField.text;
        SceneManager.LoadScene("Leaderboard");
    }
}
