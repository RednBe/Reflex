using System.Collections.Generic;
using UnityEngine;

public class AvrageMemory : MonoBehaviour
{
    public static AvrageMemory instance;

    private void Awake()
    {
        instance = this;
    }

    List<float> scores = new List<float>();
    private bool isSetted;

    public void AddScore(float score)
    {
        scores.Add(score);
    }

    private void Update()
    {
        SetAverage();
    }

    public float GetAvrage()
    {
        float total = 0f;
        foreach (float score in scores)
        {
            total += score;
        }
        float avrage = total / scores.Count;
        return avrage;
    }

    public void SetAverage()
    {
        if (!PlayerMenager.instance.isGameOver && !isSetted) return;

        AverageMenager.instance.Average = GetAvrage();
        AverageMenager.instance.SaveAverage();
        isSetted = true;
    }

    public void ResetMemory()
    {
        scores.Clear();
    }
}
