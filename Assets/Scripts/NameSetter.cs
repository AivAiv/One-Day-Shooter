using TMPro;
using UnityEngine;

public class NameSetter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMP_Text>().text = SessionData.Name;
    }
}
