using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FollowFinger : MonoBehaviour
{
    private Rigidbody2D rigid;

    private Vector3 playerpos;

    private bool canDrag = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerpos = new Vector3(0, -0.8f, 0);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (!mouseIsOverButton(Input.mousePosition)) {
                canDrag = true;
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
            canDrag = false;
        }

        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                if (!mouseIsOverButton(Input.GetTouch(0).position)) {
                    canDrag = true;
                }
            }
        }

        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                canDrag = false;
            }
        }

        if (canDrag) {
            if (Input.touchCount > 0)
            {
                playerpos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, 0);
            }
            else if (Input.GetMouseButton(0))
            {
                playerpos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            }
        }

        transform.position = playerpos;
    }

    private bool mouseIsOverButton(Vector3 position)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = position;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i < raycastResultList.Count; i++) {
            if (raycastResultList[i].gameObject.GetComponent<Button>() == null) {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }

        return raycastResultList.Count > 0;
    }
}
