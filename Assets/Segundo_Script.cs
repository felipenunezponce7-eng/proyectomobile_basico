using UnityEngine;
using UnityEngine.UI;

public class ManagerSwipe : MonoBehaviour
{
    public float minSwipeDistance = 100f;

    private Vector2 startPos;
    private Vector2 endPos;

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startPos = touch.position;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            endPos = touch.position;
            DetectSwipe();
        }
    }

    void DetectSwipe()
    {
        Vector2 delta = endPos - startPos;

        if (delta.magnitude < minSwipeDistance)
            return;

        Image img = GetComponent<Image>();

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (delta.x > 0)
            {
                Debug.Log("Swipe Right");
                img.color = Color.red;
            }
            else
            {
                Debug.Log("Swipe Left");
                img.color = Color.blue;
            }
        }
        else
        {
            if (delta.y > 0)
            {
                Debug.Log("Swipe Up");
                img.color = Color.yellow;
            }
            else
            {
                Debug.Log("Swipe Down");
                img.color = Color.green;
            }
        }
    }
}