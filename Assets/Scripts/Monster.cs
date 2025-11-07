using UnityEngine;

public class Monster : MonoBehaviour {
    public int requiredCount = 10;

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        int have = GameManager.Instance.humansCount;
        if (have >= requiredCount) GameManager.Instance.Win();
        else GameManager.Instance.Lose();
    }
}
