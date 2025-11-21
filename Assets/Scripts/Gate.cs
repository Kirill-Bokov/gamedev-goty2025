using System;
using UnityEngine;

public class Gate : MonoBehaviour {
    public int value = 2; 
    private CrowdManager _crowdManager;

    private void OnEnable()
    {
        CrowdManager.OnGameStart += GetCrowdManagerByObserver;
    }

    private void OnDisable()
    {
        CrowdManager.OnGameStart -= GetCrowdManagerByObserver;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out PlayerController playerControler))
        {
            if (_crowdManager == null) return;
            Debug.Log($"{other.name} is at {other.transform.position}, gate value: {value}");
            _crowdManager.AddHumans(value);
            gameObject.SetActive(false);
        }
        else
        {
            throw new NotImplementedException($"PlayerController not implemented on {other.name}");
        }
    }

    private void GetCrowdManagerByObserver(CrowdManager cm)
    {
        _crowdManager = cm;
        Debug.Log($"Crowd manager reference acquired by {this.gameObject.name}");
    }
    
}


