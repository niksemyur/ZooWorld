using UnityEngine;
using DG.Tweening;

public class AnimalLabelController : MonoBehaviour
{

    private Transform cameraTransform;

    public void Initialization ()
    {
        cameraTransform = Camera.main.transform;
        gameObject.SetActive(false);
    }

    public void ShowLabel()
    {
        if (gameObject.activeInHierarchy) return; //������� ���� ����� ��� ����������� ������ �������
        LookAtCamera();
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(1.1f, 0.4f) // ������� ����������� ������� �� 1.1 �� 0.4 ���
                    .OnKill(() =>
                    {
                        // ����� �����, ��������� ���������� �� 1 �� 0.1 ���
                        transform.DOScale(1f, 0.1f).OnKill(() =>
                        {
                            //����� �������� ��������� ������ ������ 0.5 ���
                            DOVirtual.DelayedCall(0.5f, () => gameObject.SetActive(false));
                        });
                    });
    }

    private void LateUpdate()
    {
        LookAtCamera();
    }

    private void LookAtCamera ()
    {
        transform.eulerAngles = new Vector3 (cameraTransform.eulerAngles.x, 0, 0);
    }
}
