using UnityEngine;

public class Gate : MonoBehaviour
{
    public GatePart leftPart;
    public GatePart rightPart;
    private CrowdManager _crowdManager;
    private bool _applied = false;

    private void OnEnable()
    {
        CrowdManager.OnGameStart += SetCrowdManager;
    }

    private void OnDisable()
    {
        CrowdManager.OnGameStart -= SetCrowdManager;
    }

    private void Start()
    {
        leftPart.parentGate = this;
        rightPart.parentGate = this;

        if (Random.value < 0.5f)
        {
            leftPart.mustBePositive = true;
            rightPart.mustBePositive = false;
        }
        else
        {
            leftPart.mustBePositive = false;
            rightPart.mustBePositive = true;
        }

        leftPart.RandomizeGate(leftPart.mustBePositive);
        rightPart.RandomizeGate(rightPart.mustBePositive);
    }

    private void SetCrowdManager(CrowdManager cm)
    {
        _crowdManager = cm;
    }

    public void ApplyGatePart(GatePart part)
    {
        if (_applied) return; 

        _applied = true; 
        if (_crowdManager != null)
            _crowdManager.AddHumans(part.value);
        gameObject.SetActive(false);
    }
}

