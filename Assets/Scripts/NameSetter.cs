using TMPro;
using UnityEngine;

public class NameSetter : MonoBehaviour
{
    [SerializeField] private UserInfo userInfo;
    private void Start()
    {
        GetComponent<TMP_Text>().text = userInfo.name;
    }
}
