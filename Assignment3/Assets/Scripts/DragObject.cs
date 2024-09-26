using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class DragObject : MonoBehaviour

{
    private Vector3 mOffset;

    void OnMouseDown()
    {
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        Debug.Log(mousePoint);
        Vector3 targetPosition = new Vector3(mousePoint.x, 1, mousePoint.y);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        
    }

}