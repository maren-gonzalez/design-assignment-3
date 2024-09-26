using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 target;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos =  Input.mousePosition;
        mousePos.z = 100f;
        mousePos = mainCam.WorldToScreenPoint(mousePos);
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)  && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                target = hit.point;
                target.y = 1;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
