using UnityEngine;

public class BestMenager : MonoBehaviour
{
    public static BestMenager instance;

    public float BestScore;

    private void Awake()
    {
        instance = this;
        BestScore = PlayerPrefs.GetFloat("BestScore", 0f);
    }

    public void SaveBest()
    {
        PlayerPrefs.SetFloat("BestScore", BestScore);
    }

    public float GetBest()
    {
        BestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        return BestScore;
    }

    public void ResetBest()
    {
        BestScore = 0;
        SaveBest();
    }
}
