using UnityEngine;

public class AverageMenager : MonoBehaviour
{
    public static AverageMenager instance;

    public float Average;

    private void Awake()
    {
        instance = this;
        Average = PlayerPrefs.GetFloat("Average", 0f);
    }

    public void SaveAverage()
    {
        PlayerPrefs.SetFloat("Average", Average);
    }

    public void ResetAverage()
    {
        Average = 0;
        SaveAverage();
    }

    public static float GetAverage()
    {
        return instance.Average;
    }
}
