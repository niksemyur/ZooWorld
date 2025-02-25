using UnityEngine;
using UnityEngine.InputSystem.XR;


public abstract class Animal : MonoBehaviour
{
    protected Rigidbody rb;
    protected Animator animator;

    private Vector3 moveTargetPosition;
    private AnimalLabelController animalLabelController;

    private GameController gameController;
    public abstract void Move();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        if (rb == null)
        {
            Debug.LogError("rigidbody не назначен!");
        }
        if (animator == null)
        {
            Debug.LogError("animator не назначен!");
        }
        if (gameController == null)
        {
            Debug.LogError("gameController не назначен!");
        }

        if (CompareTag("Predator")) //Получение AnimalLabelController для хищников
        {
            animalLabelController = transform.Find("AnimalLabelController")?.GetComponent<AnimalLabelController>();
            if (animalLabelController == null)
                Debug.LogError("animalLabelController не назначен!");
            else
                animalLabelController.Initialization();
        }

        SetMoveTargetPosition();
    }

    private void Update()
    {
        Move();  // Вызываем метод движения
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Predator"))
        {
            if (collision.gameObject.CompareTag("Predator"))
            {
                if (!collision.gameObject.activeInHierarchy)
                {
                    ShowLabel();
                    return;  //Если одно из животных уже уничтожено внутри своего класса, выходим и вызываем текст
                }

                if (!gameObject.activeInHierarchy) return;  // Если наше животное уничтожено выходим

                if (Random.Range(0, 2) == 0)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);  // Уничтожаем текущее животное
                }
                else
                {
                    collision.gameObject.SetActive(false);
                    Destroy(collision.gameObject);  // Уничтожаем столкнувшееся животное
                    ShowLabel();
                }
                gameController.AddDeadAnimal(true);
            }
            else if (collision.gameObject.CompareTag("Prey"))
            {
                gameController.AddDeadAnimal(false);
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);  // Уничтожаем столкнувшееся животное
                ShowLabel();
            }
        }
    }

    private void SetMoveTargetPosition ()
    {
        moveTargetPosition = CameraBoundsHelper.GetRandomPointInBounds();
        transform.LookAt(moveTargetPosition);
    }

    public void CheckBounds()
    {
        Vector3 screenPos = CameraBoundsHelper.ConvertWorldToViewport(transform.position);

        // Проверяем, вышел ли объект за границы (меньше 0 или больше 1 по любой координате)
        if (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
        {
            SetMoveTargetPosition();
        }
    }
    private void ShowLabel()
    {
        animalLabelController.ShowLabel();
    }


}
