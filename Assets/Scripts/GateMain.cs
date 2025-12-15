using UnityEngine;

public class Gate : MonoBehaviour
{
    public GatePart leftPart;
    public GatePart rightPart;
    private CrowdManager _crowdManager;
    private bool _applied = false; // флаг, чтобы значение применялось только один раз

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

        // Случайно выбираем, какая часть будет гарантированно положительной
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

        // Генерируем значения для обеих частей
        leftPart.RandomizeGate(leftPart.mustBePositive);
        rightPart.RandomizeGate(rightPart.mustBePositive);
    }

    private void SetCrowdManager(CrowdManager cm)
    {
        _crowdManager = cm;
    }

    public void ApplyGatePart(GatePart part)
    {
        if (_applied) return; // если уже применялось, выходим

        _applied = true; // ставим флаг
        if (_crowdManager != null)
            _crowdManager.AddHumans(part.value);

        // Деактивируем весь объект
        gameObject.SetActive(false);
    }
}

