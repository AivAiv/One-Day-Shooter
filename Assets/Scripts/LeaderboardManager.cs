using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
     [SerializeField] private GameObject leaderboardItemPrefab;
     [SerializeField] private LeaderboardData leaderboardData;
     [SerializeField] private GameObject leaderboardItemContainer;
     
     private void Start()
     {
          leaderboardData.Data.Sort((a, b) => b.kills.CompareTo(a.kills));
          foreach (var data in leaderboardData.Data)
          {
               var leaderboardItem = Instantiate(leaderboardItemPrefab, leaderboardItemContainer.transform);
               leaderboardItem.GetComponent<LeaderboardItem>().SetData(data);
          }
     }

     /// <summary>
     /// The callback back button will call when clicked
     /// </summary>
     public void GoBack()
     {
          SceneManager.LoadScene("Main Menu");
     }
}
