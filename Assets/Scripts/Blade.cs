using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;
    private Rigidbody2D rb;
    private Vector3 lastMousePos;

    private Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = IsMouseMoving();
        col.enabled = temp;
        if(temp)
            SetBladeToMouse();
        
    }
    void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    bool IsMouseMoving()
    {
        Vector3 curMousePos = Input.mousePosition;
        float traveled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;
        if (traveled >= minVelo) return true;
        return false;
    }
}
