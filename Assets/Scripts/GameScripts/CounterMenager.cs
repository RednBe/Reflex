using TMPro;
using UnityEngine;

public class CounterMenager : MonoBehaviour
{
    float count = 0;
    public bool isReseted = false;

    float score;
    bool isScoreControled = true;

    [SerializeField] private ControlerMenager controler;

    private void Update()
    {
        if (controler.isActive)
        {
            isScoreControled = false;
            Reset();
            Count();
        }
        else if (!isScoreControled)
        {
            isScoreControled = true;
            score = count;
            AvrageMemory.instance.AddScore(score);
            BestMemory.instance.currentScore = score;
        }
    }

    public void Count()
    {
        count += Time.deltaTime;
        GetComponent<TextMeshProUGUI>().text = count.ToString("F2");
    }

    public void Reset()
    {
        if (isReseted) return;

        count = 0;
        GetComponent<TextMeshProUGUI>().text = count.ToString("F2");
        isReseted = true;
    }
}