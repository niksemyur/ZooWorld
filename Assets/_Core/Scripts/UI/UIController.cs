using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deadPredatorsText;
    [SerializeField] private TextMeshProUGUI deadPreysText;

    public void DisplayDeadPredatorsInfo(int value)
    {
        deadPredatorsText.text = "Dead Predators: " + value.ToString();
    }

    public void DisplayDeadPreysInfo(int value)
    {
        deadPreysText.text = "Dead Preys: " + value.ToString();
    }

}
