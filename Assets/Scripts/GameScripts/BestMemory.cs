using UnityEngine;

public class BestMemory : MonoBehaviour
{
    public static BestMemory instance;

    float bestScore;
    public float currentScore;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        SetBest();
    }

    public void SetBest()
    {
        if (bestScore == 0)
        {
            bestScore = currentScore;
        }
        else if (currentScore < bestScore)
        {
            bestScore = currentScore;
        }

        BestMenager.instance.BestScore = bestScore;
        BestMenager.instance.SaveBest();
    }
}
