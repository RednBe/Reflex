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

    public void AddScore(float score)
    {
        scores.Add(score);
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
}
