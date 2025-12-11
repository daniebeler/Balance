using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// New Input System namespace
using UnityEngine.InputSystem;

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
        // -----------------------------
        // Pointer Down (mouse or touch)
        // -----------------------------
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            Vector2 screenPos = Pointer.current.position.ReadValue();
            if (!PointerIsOverUIButton(screenPos))
                canDrag = true;
        }

        // -----------------------------
        // Pointer Up
        // -----------------------------
        if (Pointer.current != null && Pointer.current.press.wasReleasedThisFrame)
        {
            canDrag = false;
        }

        // -----------------------------
        // Drag movement
        // -----------------------------
        if (canDrag && Pointer.current != null && Pointer.current.press.isPressed)
        {
            Vector2 screenPos = Pointer.current.position.ReadValue();
            Vector3 world = Camera.main.ScreenToWorldPoint(screenPos);
            playerpos = new Vector3(world.x, world.y, 0);
        }

        transform.position = playerpos;
    }

    // Replaces your old mouseIsOverButton()
    private bool PointerIsOverUIButton(Vector2 screenPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = screenPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var r in results)
        {
            if (r.gameObject.GetComponent<Button>() != null)
                return true;
        }

        return false;
    }
}
