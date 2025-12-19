using System;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public GameObject humanPrefab;
    public Transform spawnRoot;
    [SerializeField] private int _numberOfRows; 
    [SerializeField] private int _numberOfColumns;  
    public List<GameObject> humans = new List<GameObject>();
    public float offset = 0.4f;  
    public static Action<CrowdManager> OnGameStart;

    void Start()
    {
        if (humanPrefab == null) Debug.LogError("Human prefab not assigned");
        AddHumans(GameManager.Instance.humansCount - humans.Count);
        OnGameStart?.Invoke(this);
    }

    public void AddHumans(int delta)
    {
        if (delta > 0)
        {
            for (int i = 0; i < delta; i++)
            {
                int index = humans.Count;
                int row = index % _numberOfRows;  
                int col = index / _numberOfRows;  
                Vector3 basePos = humans.Count == 0 ? transform.position : humans[0].transform.position;
                Vector3 worldPos = basePos + new Vector3(col * offset, 0, row * offset);

                GameObject h = Instantiate(humanPrefab, worldPos, Quaternion.identity, transform);
                h.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

                humans.Add(h);
            }
        }
        else if (delta < 0)
        {
            int remove = Mathf.Min(humans.Count, Mathf.Abs(delta));
            for (int i = 0; i < remove; i++)
            {
                GameObject last = humans[humans.Count - 1];
                Destroy(last);
                humans.RemoveAt(humans.Count - 1);
            }
        }

        GameManager.Instance.SetHumansCount(humans.Count);
    }
}

