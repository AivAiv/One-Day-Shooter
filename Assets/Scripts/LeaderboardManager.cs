using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
     [SerializeField] private GameObject leaderboardItemPrefab;
     [SerializeField] private GameObject leaderboardItemContainer;
     
     private void Start()
     {
          foreach (var data in Leaderboard.Get())
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
