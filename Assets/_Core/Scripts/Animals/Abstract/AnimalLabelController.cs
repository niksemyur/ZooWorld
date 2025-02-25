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
        if (gameObject.activeInHierarchy) return; //выходим если текст уже активирован другой жертвой
        LookAtCamera();
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(1.1f, 0.4f) // Сначала увеличиваем масштаб до 1.1 за 0.4 сек
                    .OnKill(() =>
                    {
                        // После этого, анимируем уменьшение до 1 за 0.1 сек
                        transform.DOScale(1f, 0.1f).OnKill(() =>
                        {
                            //после анимации выключаем объект спустя 0.5 сек
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
