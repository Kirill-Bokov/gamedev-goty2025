using System;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour {
    public GameObject humanPrefab;
    public Transform spawnRoot;
    [SerializeField] private int _numberOfColumns;
    public List<GameObject> humans = new List<GameObject>();
    public float offset = 0.4f;
    public static Action<CrowdManager> OnGameStart;
    void Start() {
        if (humanPrefab == null) Debug.LogError("Human prefab not assigned");
        // Создаем стартового человека-ледера как часть толпы
        AddHumans(GameManager.Instance.humansCount - humans.Count);
        OnGameStart?.Invoke(this);
    }

    public void AddHumans(int delta) {
        if (delta > 0) {
            for (int i = 0; i < delta; i++) {
                Vector3 pos = (spawnRoot != null ? spawnRoot.position : transform.position) + offsetStep * humans.Count;
                GameObject h = Instantiate(humanPrefab, pos, Quaternion.identity, transform);
                h.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
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


