using UnityEngine;

public class InputControl : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    public Vector3 GetMovementVector()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        return new Vector3(_horizontal, 0f, _vertical).normalized;
    }

    public bool IsJumping()
    {
        return Input.GetButtonDown("Jump");
    }

    public bool IsUsing()
    {
        return Input.GetButton("Use");
    }
}
