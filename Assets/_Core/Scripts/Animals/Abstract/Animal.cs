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
            Debug.LogError("rigidbody �� ��������!");
        }
        if (animator == null)
        {
            Debug.LogError("animator �� ��������!");
        }
        if (gameController == null)
        {
            Debug.LogError("gameController �� ��������!");
        }

        if (CompareTag("Predator")) //��������� AnimalLabelController ��� ��������
        {
            animalLabelController = transform.Find("AnimalLabelController")?.GetComponent<AnimalLabelController>();
            if (animalLabelController == null)
                Debug.LogError("animalLabelController �� ��������!");
            else
                animalLabelController.Initialization();
        }

        SetMoveTargetPosition();
    }

    private void Update()
    {
        Move();  // �������� ����� ��������
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
                    return;  //���� ���� �� �������� ��� ���������� ������ ������ ������, ������� � �������� �����
                }

                if (!gameObject.activeInHierarchy) return;  // ���� ���� �������� ���������� �������

                if (Random.Range(0, 2) == 0)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);  // ���������� ������� ��������
                }
                else
                {
                    collision.gameObject.SetActive(false);
                    Destroy(collision.gameObject);  // ���������� ������������� ��������
                    ShowLabel();
                }
                gameController.AddDeadAnimal(true);
            }
            else if (collision.gameObject.CompareTag("Prey"))
            {
                gameController.AddDeadAnimal(false);
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);  // ���������� ������������� ��������
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

        // ���������, ����� �� ������ �� ������� (������ 0 ��� ������ 1 �� ����� ����������)
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
