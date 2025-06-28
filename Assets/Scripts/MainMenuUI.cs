using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The script handling the main menu scene
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private UserInfo userInfo;

    private void Start()
    {
        if (string.IsNullOrEmpty(userInfo.name)) return;
        nameInputField.text = userInfo.name;
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

        userInfo.name = nameInputField.text;
        SceneManager.LoadScene("Game Scene");
    }
    
    /// <summary>
    /// The callback that the leaderboard button calls when clicked
    /// </summary>
    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
