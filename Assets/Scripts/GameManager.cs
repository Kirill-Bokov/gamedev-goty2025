using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public int humansCount = 1;
    public bool isGameOver = false;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetHumansCount(int count)
{
    humansCount = count;
    if (humansCount <= 0) Lose();
}

    public void Lose() {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Поражение");
        Invoke(nameof(Restart), 2f);
    }

    public void Win() {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Победа");
        Invoke(nameof(Restart), 2f);
    }
    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
