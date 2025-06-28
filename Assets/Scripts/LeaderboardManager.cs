using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
     [SerializeField] private GameObject leaderboardItemPrefab;
     [SerializeField] private LeaderboardData leaderboardData;
     [SerializeField] private GameObject leaderboardItemContainer;
     
     private void Start()
     {
          foreach (var data in leaderboardData.Data)
          {
               var leaderboardItem = Instantiate(leaderboardItemPrefab, leaderboardItemContainer.transform);
               leaderboardItem.GetComponent<LeaderboardItem>().SetData(data);
          }
     }
}
