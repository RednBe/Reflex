using UnityEngine;

public class BestMemory : MonoBehaviour
{
    public static BestMemory instance;

    float bestScore;
    float currentScore;

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
        if (currentScore >= bestScore && currentScore != 0) return;

        bestScore = currentScore;
        BestMenager.instance.BestScore = bestScore;
    }
}
