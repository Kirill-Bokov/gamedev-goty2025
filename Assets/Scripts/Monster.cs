using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
    public int requiredCount = 10;
    public TextMeshPro textDisplay;  

    private void Start()
    {
        if (textDisplay != null)
        {
            textDisplay.text = requiredCount.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        int have = GameManager.Instance.humansCount;
        if (have >= requiredCount)
        {
            GameManager.Instance.Win();
        }
        else
        {
            GameManager.Instance.Lose();
        }
    }
}
