using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [Header("References")]
    private Animator anim;
    private PlayerCombatManager playerCombatManager;

    [Header("Parameters")]
    public Vector2 moveInput;
    public bool attackInput;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerCombatManager = GetComponent<PlayerCombatManager>();
    }

    private void LateUpdate()
    {
        attackInput = false;

    }

    #region Input Events
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        // Only set the animation direction if the player is trying to move
        if (moveInput != Vector2.zero)
        {
            anim.SetFloat("XInput", moveInput.x);
            anim.SetFloat("YInput", moveInput.y);
        }

    }

    void OnFire(InputValue value)
    {
        
        if (value.Get<float>() == 1)
        {
            attackInput = true;
        }

        playerCombatManager.Attack();
    }

    #endregion
}
