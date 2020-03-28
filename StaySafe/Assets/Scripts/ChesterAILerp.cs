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

    public void FixedUpdate()
    {

    }
    /**
    protected override void Update()
    {
        if (shouldRecalculatePath) SearchPath();
        if (canMove)
        {
            Vector3 nextPosition;
            Quaternion nextRotation;
            MovementUpdate(Time.deltaTime, out nextPosition, out nextRotation);
            FinalizeMovement(nextPosition, nextRotation);
        }
    }
    public void FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
    {
        previousPosition2 = previousPosition1;
        previousPosition1 = simulatedPosition = nextPosition;
        simulatedRotation = nextRotation;
        if (updatePosition) { 
        
            Vector3 looker = (GetComponentInParent<Rigidbody2D>().position - new Vector2(nextPosition.x,nextPosition.y)).normalized;
            Debug.DrawLine(GetComponentInParent<Rigidbody2D>().position, -nextPosition, Color.red, 2.5f);
            Debug.DrawLine(GetComponentInParent<Rigidbody2D>().position, looker, Color.blue, 2.5f);
            //Debug.Log(looker);
            //GetComponentInParent<Rigidbody2D>().AddForce(looker * Time.deltaTime * 5f);
            tr.position = nextPosition;
        }
        if (updateRotation) tr.rotation = nextRotation;
    }
    /// <summary>\copydoc Pathfinding::IAstarAI::MovementUpdate</summary>
    public void MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
    {
        if (updatePosition) simulatedPosition = tr.position;
        if (updateRotation) simulatedRotation = tr.rotation;

        Vector3 direction;

        nextPosition = CalculateNextPosition(out direction, isStopped ? 0f : deltaTime);

        if (enableRotation) nextRotation = SimulateRotationTowards(direction, deltaTime);
        else nextRotation = simulatedRotation;
    }
    /// <summary>Calculate the AI's next position (one frame in the future).</summary>
    /// <param name="direction">The tangent of the segment the AI is currently traversing. Not normalized.</param>
    /// 
    protected override Vector3 CalculateNextPosition(out Vector3 direction, float deltaTime)
    {
        
        if (!interpolator.valid)
        {
            direction = Vector3.zero;
            return simulatedPosition;
        }

        interpolator.distance += deltaTime * speed;

        if (interpolator.remainingDistance < 0.0001f && !reachedEndOfPath)
        {
            base.reachedEndOfPath = true;
            OnTargetReached();
        }
        
        direction = interpolator.tangent;
        pathSwitchInterpolationTime += deltaTime;
        return interpolator.position;
    }**/
}
