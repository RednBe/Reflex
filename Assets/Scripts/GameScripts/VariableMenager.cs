using TMPro;
using UnityEngine;

public class VariableMenager : MonoBehaviour
{
    public int Max;
    int current;

    [SerializeField] string type;

    private TextMeshProUGUI tmpUGUI;
    private TextMeshPro tmpMesh;

    private void Awake()
    {
        tmpUGUI = GetComponent<TextMeshProUGUI>();
        tmpMesh = GetComponent<TextMeshPro>();

        if (tmpUGUI == null && tmpMesh == null)
        {
            Debug.LogError($"VariableMenager requires a TextMeshPro or TextMeshProUGUI on '{gameObject.name}'.");
        }
    }

    private void Start()
    {
        current = 0;

        // Use MenuMenager static values to avoid start-order race conditions
        if (type == "corrects")
            Max = MenuMenager.CurrentMaxCorrects;
        else if (type == "mistakes")
            Max = MenuMenager.CurrentMaxMistakes;

        UpdateText();
    }

    private void Update()
    {
        AdjustText();
    }

    public void Increase()
    {
        if (current < Max)
            current++;
    }

    public void AdjustText()
    {
        string display = current + " / " + Max;
        if (tmpUGUI != null) tmpUGUI.text = display;
        else if (tmpMesh != null) tmpMesh.text = display;
    }

    public void Reset()
    {
        current = 0;
        AdjustText();
    }

    private void UpdateText() => AdjustText();
}