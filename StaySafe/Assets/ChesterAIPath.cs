using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChesterAIPath : AIPath
{
    public void EnableNavigation()
    {
        this.canMove = true;
    }
}