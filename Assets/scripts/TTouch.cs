using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTouch : MonoBehaviour
{
    private Touch oldTouch1;
    private Touch oldTouch2;
    public float speed = 0.0005F;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        }

        if (Input.touchCount > 1)
        {
            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);

            if (newTouch2.phase == TouchPhase.Began)
            {
                oldTouch2 = newTouch2;
                oldTouch1 = newTouch1;
                return;
            }

            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

            float offset = newDistance - oldDistance;

            float scaleFactor = offset / 200f;
            Vector3 localScale = transform.localScale;
            Vector3 scale = new Vector3(localScale.x + scaleFactor, localScale.y + scaleFactor, localScale.z + scaleFactor);

            if (scale.x > 0.3f && scale.y > 0.3f && scale.z > 0.3f)
            {
                transform.localScale = scale;
            }

            oldTouch1 = newTouch1;
            oldTouch2 = newTouch2;
        }

    }
}
