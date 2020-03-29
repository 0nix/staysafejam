﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

using Pathfinding;

public class InputManager : MonoBehaviour
{
    TestControls _controls = null;
    public ChesterAILerp[] chester = null;
    private List<GameObject> positionPool = new List<GameObject>();
    //public ChesterAIPath[] chesterpath = null;
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
            Debug.DrawLine(Vector3.zero, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            MoveProjectedCursor();
           
        }
    }

    void MoveProjectedCursor()
    {
        
        Vector3 ray = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        if (projected != null)
        {
            projected.transform.position = new Vector3(ray.x, ray.y);

            for (var i = 0; i < chester.Length; i++)
            {
                if (chester[i] != null)
                {
                    //GameObject pos = positionPool[i];
                    Transform pos = projected.transform.GetChild(i);
                    ChesterAILerp ca = chester[i];
                    ca.SetTarget(pos.transform);
                    ca.EnableNavigation();
                }
            }
            
        }
    }

    void Start()
    {
        //InvokeRepeating("ScanGraph", 0.0f, 0.25f);
        
    }

    void ScanGraph()
    {
        AstarPath.active.Scan();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
