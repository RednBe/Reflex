using TMPro;
using UnityEngine;

public class CounterMenager : MonoBehaviour
{
    float count = 0;
    public bool isReseted = false;
    [SerializeField] private ControlerMenager controler;

    private void Update()
    {
        if (controler.isActive)
        {
            Reset();
            Count();
        }
    }

    public void Count()
    {
        count += Time.deltaTime;
        GetComponent<TextMeshProUGUI>().text = count.ToString("F2");
    }

    public void Reset()
    {
        if (isReseted)
            return;
        count = 0;
        GetComponent<TextMeshProUGUI>().text = count.ToString("F2");
        isReseted = true;
    }
}