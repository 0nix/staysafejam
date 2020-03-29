using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Pathfinding.Util;

public class ChesterAILerp : AILerp
{
    public Rigidbody2D rb;
    public AIDestinationSetter ds;

    public void EnableNavigation()
    {
        this.canMove = true;
    }

    public void SetTarget(Transform t)
    {
        ds.target = t;
    }
    protected override void Start()
    {
        base.Start();
        ds = GetComponentInParent<AIDestinationSetter>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
}
