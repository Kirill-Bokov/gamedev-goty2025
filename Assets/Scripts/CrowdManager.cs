using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour {
    public GameObject humanPrefab;
    public Transform spawnRoot;
    public List<GameObject> humans = new List<GameObject>();
    public Vector3 offsetStep = new Vector3(0.5f, 0f, -0.5f);

    void Start() {
        if (humanPrefab == null) Debug.LogError("Human prefab not assigned");
        // Создаем стартового человека-ледера как часть толпы
        AddHumans(GameManager.Instance.humansCount - humans.Count);
    }

    public void AddHumans(int delta) {
        if (delta > 0) {
            for (int i = 0; i < delta; i++) {
                Vector3 pos = (spawnRoot != null ? spawnRoot.position : transform.position) + offsetStep * humans.Count;
                GameObject h = Instantiate(humanPrefab, pos, Quaternion.identity, transform);
                humans.Add(h);
            }
        } else if (delta < 0) {
            int remove = Mathf.Min(humans.Count, Mathf.Abs(delta));
            for (int i = 0; i < remove; i++) {
                GameObject last = humans[humans.Count - 1];
                Destroy(last);
                humans.RemoveAt(humans.Count - 1);
            }
        }
        GameManager.Instance.AddHumans(delta);
    }

    public int Count() {
        return humans.Count;
    }
}
