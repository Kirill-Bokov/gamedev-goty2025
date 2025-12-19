using System;
using UnityEngine;
using TMPro;

public class GatePart : MonoBehaviour
{
    public int value;
    public TextMeshPro textDisplay;
    [HideInInspector] public Gate parentGate;
    public bool mustBePositive = false;

    private void Start()
    {
        RandomizeGate(mustBePositive);
    }

    public void RandomizeGate(bool ensurePositive = false)
    {
        int randomNumber = UnityEngine.Random.Range(1, 9); 
        string expr;

        if (ensurePositive)
        {
            expr = $"+{randomNumber}";
        }
        else
        {
            string sign = UnityEngine.Random.Range(0, 2) == 0 ? "+" : "-";
            expr = $"{sign}{randomNumber}";
        }

        textDisplay.text = expr;

        if (expr.StartsWith("+"))
            value = int.Parse(expr.Substring(1));
        else if (expr.StartsWith("-"))
            value = -int.Parse(expr.Substring(1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            parentGate.ApplyGatePart(this);
        }
    }
}

