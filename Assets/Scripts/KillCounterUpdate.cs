using TMPro;
using UnityEngine;

public class KillCounterUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text killsText;

    private void Start() => SessionData.Kills = 0;
    
    private void Update()
    {
        killsText.text = SessionData.Kills.ToString();
    }
}
