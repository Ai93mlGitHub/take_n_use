using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed { get; private set; } = 15f;
    public float TurnSpeed { get; private set; } = 90f;
    public float RayDistance { get; private set; } = 3f;
    public Vector3 RayPositionOffset { get; private set; } = new Vector3(0, 1, 0);

    public Movement()
    {
    }

    public Movement(float initialSpeed, float initialTurnSpeed, float initialRayDistance, Vector3 initialRayPosOffset)
    {
        MoveSpeed = initialSpeed;
        TurnSpeed = initialTurnSpeed;
        RayDistance = initialRayDistance;
        RayPositionOffset = initialRayPosOffset;
    }

    public float GetMovementDirection(Transform target, float moveDirection)
    {
        if (moveDirection > 0 && RaycastObstacleCheck(target, moveDirection))
            moveDirection = 0;

        if (moveDirection < 0 && RaycastObstacleCheck(target, moveDirection))
            moveDirection = 0;

        return moveDirection;
    }

    public void Move(Transform target, float moveDirection)
    {
        Vector3 move = target.transform.forward * moveDirection * MoveSpeed * Time.deltaTime;
        target.transform.position += move;
    }

    public void Turn(Transform target, float moveDirection, float turnDirection)
    {
        if (moveDirection < 0)
            turnDirection = -turnDirection;

        target.transform.Rotate(0f, turnDirection * TurnSpeed * Time.deltaTime, 0f);
    }

    internal void SetSpeed(float increaseValue)
    {
        MoveSpeed += increaseValue;
        Debug.Log($"new speed {MoveSpeed}");
    }

    public bool RaycastObstacleCheck(Transform target, float sign)
    {
        sign = Mathf.Sign(sign);
        Ray ray = new Ray(target.transform.position + RayPositionOffset, target.transform.forward * sign);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, RayDistance, ~0, QueryTriggerInteraction.Ignore))
            return hit.collider != null;

        return false;
    }

}
