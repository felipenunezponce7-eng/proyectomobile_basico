using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Touchd : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int valorcontador;
    public float scaleSpeed = 0.01f;
    public float minScale = 0.5f;
    public float maxScale = 3f;

    public Vector3 targetScale;
    void Start()
    {
        targetScale = transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 prevTouch0 = touch0.position - touch0.deltaPosition;
            Vector2 prevTouch1 = touch1.position - touch1.deltaPosition;

            float prevDistance = Vector2.Distance(prevTouch0, prevTouch1);
            float currentDistance = Vector2.Distance(touch0.position, touch1.position);

            float delta = currentDistance - prevDistance;

            targetScale += Vector3.one * delta * scaleSpeed;

            float clamped = Mathf.Clamp(targetScale.x, minScale, maxScale);
            targetScale = Vector3.one * clamped;

        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 10f);


    }
    public void contando()
    {
        valorcontador++;
        textMeshPro.text = valorcontador.ToString();
        Debug.Log(valorcontador);

       
    }
}

