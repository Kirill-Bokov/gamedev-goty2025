using UnityEngine;

public class Gate : MonoBehaviour {
    public int value = 2; // ставь +2 или -2 в инспекторе

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        CrowdManager cm = FindObjectOfType<CrowdManager>();
        if (cm == null) return;
        // Распределение толпы простое: изменяем общее количество
        cm.AddHumans(value);
        // Деактивировать ворота, чтобы не срабатывать повторно
        gameObject.SetActive(false);
    }
}
