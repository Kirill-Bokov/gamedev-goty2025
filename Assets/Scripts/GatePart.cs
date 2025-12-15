using System;
using UnityEngine;
using TMPro;

public class GatePart : MonoBehaviour
{
    public int value;
    public string[] possibleExpressions = { "+1", "-1", "+2", "-2" };
    public TextMeshPro textDisplay;
    [HideInInspector] public Gate parentGate;

    // Этот флаг говорит, что эта часть должна быть положительной
    public bool mustBePositive = false;

    private void Start()
    {
        RandomizeGate(mustBePositive);
    }

    public void RandomizeGate(bool ensurePositive = false)
    {
        if (possibleExpressions.Length == 0) return;

        string expr;

        if (ensurePositive)
        {
            // Выбираем только положительные выражения
            string[] positives = Array.FindAll(possibleExpressions, s => s.StartsWith("+"));
            if (positives.Length == 0)
                positives = possibleExpressions; // на случай, если плюсов нет
            expr = positives[UnityEngine.Random.Range(0, positives.Length)];
        }
        else
        {
            expr = possibleExpressions[UnityEngine.Random.Range(0, possibleExpressions.Length)];
        }

        textDisplay.text = expr;

        // Надёжное преобразование выражения в число
        expr = expr.Trim();
        if (expr.StartsWith("+"))
            value = int.Parse(expr.Substring(1));
        else if (expr.StartsWith("-"))
            value = -int.Parse(expr.Substring(1));
        else
            value = int.Parse(expr);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            parentGate.ApplyGatePart(this);
        }
    }
}

