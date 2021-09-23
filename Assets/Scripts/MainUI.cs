using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text BestScoreText;

    private void Awake()
    {
        int lastBestScore = DataStorage.Instance.GetLastBestScore();
        if (lastBestScore == 0)
        {
            BestScoreText.text = "No scores saved";
        }
        else
        {
            string lastBestScoreUserName = DataStorage.Instance.GetLastBestScorePlayerName();
            BestScoreText.text = $"Best score : {lastBestScoreUserName} : {lastBestScore}";
        }
    }
}
