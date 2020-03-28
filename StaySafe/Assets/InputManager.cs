using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    TestControls _controls = null;
    public ChesterAIPath chester = null;
    public GameObject projected = null;

    // Start is called before the first frame update
    private void Awake()
    {
        _controls = new TestControls();
    }

    private void OnEnable()
    {

        if (_controls != null)
        {
            _controls.Main.Tap.performed += HandleTap;
            _controls.Main.Enable();
        }
    }
    private void OnDisable()
    {

        if (_controls != null)
        {
            _controls.Main.Disable();
            _controls.Main.Tap.performed -= HandleTap;
        }
    }

    private void HandleTap(InputAction.CallbackContext ctx)
    {
        
        if (ctx.interaction is SlowTapInteraction)
        {
            Debug.Log("Long Tap");
        }
        else
        {
            MoveProjectedCursor();
        }
    }

    void MoveProjectedCursor()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        if (projected != null)
        {
            projected.transform.position = new Vector3(ray.x, ray.y);
            chester.EnableNavigation();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
