using UnityEngine;

public class GameController : MonoBehaviour
{
    private int deadPredatorsCount;
    private int deadPreysCount;

    private UIController uiController;

    private void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    public void AddDeadAnimal (bool IsPredator)
    {
        if (IsPredator)
        {
            deadPredatorsCount++;
            uiController.DisplayDeadPredatorsInfo(deadPredatorsCount);
        }
        else
        {
            deadPreysCount++;
            uiController.DisplayDeadPreysInfo(deadPreysCount);
        }
    }
}
