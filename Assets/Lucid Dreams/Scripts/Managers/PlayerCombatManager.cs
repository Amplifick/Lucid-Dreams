using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatManager : MonoBehaviour
{
    [Header("References")]
    PlayerHandler playerHandler;
    PlayerAnimatorManager playerAnimatorManager;

    InventoryManager inventoryManager;

    public bool isAttacking = false;

    private void Start()
    {
        playerHandler = GetComponent<PlayerHandler>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        inventoryManager = GetComponent<InventoryManager>();
    }

    public void Attack()
    {

        if (playerHandler.isInteracting)
            return;

        //Checking to which side is the player facing at the moment he attacks so we can decide which animation we should play
        if (playerAnimatorManager.anim.GetFloat("XInput") == 1 || playerAnimatorManager.anim.GetFloat("YInput") == 1 || (playerAnimatorManager.anim.GetFloat("XInput") == 0 && playerAnimatorManager.anim.GetFloat("YInput") == 0))
        {
            playerAnimatorManager.PlayTargetAnimation(inventoryManager.rightWeapon.basicAttack_R, true);
            //lastAttack = weapon.attackAnimation;
        }
        else if (playerAnimatorManager.anim.GetFloat("XInput") == -1 || playerAnimatorManager.anim.GetFloat("YInput") == -1)
        {
            playerAnimatorManager.PlayTargetAnimation(inventoryManager.rightWeapon.basicAttack_L, true);
            //lastAttack = weapon.attackAnimation;
        }

    }
}
