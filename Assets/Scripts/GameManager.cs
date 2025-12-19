using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int humansCount = 1;
    public bool isGameOver = false;

    public GameObject winPanel;  
    public TextMeshProUGUI winText;  
    public Button exitButton;  
    public Button restartButton;  

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetHumansCount(int count)
    {
        humansCount = count;
        if (humansCount <= 0) Lose();
    }

    public void Lose()
    {
        if (isGameOver) return;
        isGameOver = true;
        ShowEndScreen("Поражение :(");
    }

    public void Win()
    {
        if (isGameOver) return;
        isGameOver = true;
        ShowEndScreen("Победа!");
    }

    private void ShowEndScreen(string result)
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);  
            winText.text = result;  
        }

        if (exitButton != null)
        {
            exitButton.gameObject.SetActive(true);  
            exitButton.onClick.AddListener(QuitGame);  
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);  
            restartButton.onClick.AddListener(RestartGame);  
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }

    private void QuitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }
}


