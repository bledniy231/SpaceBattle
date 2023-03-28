using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Tooltip("Цель за которой следует камера")]
    public Transform followTransform;

    // Смещение относительн цели
    // определяется автоматически на старте
    Vector3 delta;

    [Tooltip("Чувствительность к вращение колесика мыши")]
    public float scrollSens = 0.5f;

    public float scrollMax = 5;
    public float scrollMin = -5;
    public float scroll;

    void Start ()
    {
        delta = this.transform.position - followTransform.position;
    }
	
	void Update ()
    {
        if (followTransform != null)
        {
            // Регистрируем вращение колесика
            scroll += Input.mouseScrollDelta.y * scrollSens;

            // Накладываем ограничение
            scroll = Mathf.Clamp(scroll, scrollMin, scrollMax);

            transform.position = followTransform.position + delta + transform.forward * scroll;

        }
    }
}
