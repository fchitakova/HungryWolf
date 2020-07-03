using System;
using UnityEngine;


[Serializable]
internal class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    internal bool isAttackPressed;
    internal Vector2 movement;
    internal bool moveAttempted;

    public void Update()
    {
        isAttackPressed = Input.GetKeyDown(KeyCode.Space);
        GetMovementInput();
        UpdateMoveAttemptInfo();
    }

    private void GetMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void UpdateMoveAttemptInfo() {
        moveAttempted = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow);
    }

}