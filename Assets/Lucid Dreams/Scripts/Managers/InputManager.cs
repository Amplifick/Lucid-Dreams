using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [Header("References")]
    PlayerHandler playerHandler;
    private PlayerAnimatorManager playerAnimatorManager;
    private PlayerCombatManager playerCombatManager;

    [Header("Parameters")]
    public Vector2 moveInput;

    private void Start()
    {
        playerHandler = GetComponent<PlayerHandler>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerCombatManager = GetComponent<PlayerCombatManager>();
    }

    #region Input Events
    void OnMove(InputValue value)
    {

        moveInput = value.Get<Vector2>();

        // Only set the animation direction if the player is trying to move
        if (moveInput != Vector2.zero)
        {
            playerAnimatorManager.anim.SetFloat("XInput", moveInput.x);
            playerAnimatorManager.anim.SetFloat("YInput", moveInput.y);
        }

    }

    void OnFire(InputValue value)
    {

        if (value.Get<float>() == 1)
        {
            playerCombatManager.Attack();
        }

    }

    #endregion
}
