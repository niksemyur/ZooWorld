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

        if (CompareTag("Predator")) // Get the AnimalLabelController for predators
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
        Move();
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
                    return;  // If one of the animals is already destroyed within its class, exit and trigger the text
                }

                if (!gameObject.activeInHierarchy) return;  // If this animal is destroyed, exit

                if (Random.Range(0, 2) == 0)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);  // Destroy this animal
                }
                else
                {
                    collision.gameObject.SetActive(false);
                    Destroy(collision.gameObject);  // Destroy collision animal
                    ShowLabel();
                }
                gameController.AddDeadAnimal(true);
            }
            else if (collision.gameObject.CompareTag("Prey"))
            {
                gameController.AddDeadAnimal(false);
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);  // Destroy collision animal
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

        // Check if the object has gone out of bounds (less than 0 or greater than 1 on any coordinate)
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
