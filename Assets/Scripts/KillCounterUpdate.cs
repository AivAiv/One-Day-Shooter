using TMPro;
using UnityEngine;

public class KillCounterUpdate : MonoBehaviour
{
    [SerializeField] private UserInfo userInfo;
    [SerializeField] private TMP_Text killsText;

    private void Start()
    {
        userInfo.kills = 0;
    }
    
    private void Update()
    {
        killsText.text = userInfo.kills.ToString();
    }
}
