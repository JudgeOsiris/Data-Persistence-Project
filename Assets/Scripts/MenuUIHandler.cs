using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField PlayerNameInputField;
    public Text LastBestScore;

    private void Awake()
    {
        LastBestScore.gameObject.SetActive(false);
        PlayerNameInputField.text = DataStorage.Instance.GetPlayerName();
    }
    
    public void StartGame()
    {
        if (PlayerNameInputField.text.Length > 0)
        {
            DataStorage.Instance.StorePlayerName(PlayerNameInputField.text);
            DataStorage.Instance.SaveDataToStorage();
            SceneManager.LoadScene(1);
        }
    }

    public void ShowHideLastBestScore()
    {
        int lastBestScore = DataStorage.Instance.GetLastBestScore();
        if (lastBestScore == 0)
        {
            LastBestScore.text = "No scores saved";
        }
        else
        {
            string lastBestScoreUserName = DataStorage.Instance.GetLastBestScorePlayerName();
            LastBestScore.text = $"Best score : {lastBestScoreUserName} : {lastBestScore}";
        }
        LastBestScore.gameObject.SetActive(!LastBestScore.gameObject.activeSelf);
    }
}
