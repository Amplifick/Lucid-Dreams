using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatManager : MonoBehaviour
{
    [HideInInspector]
    Animator anim;
    InputManager inputManager;
    //InventoryManager inventoryManager;

    public WeaponItem weapon; // Just for now, must be removed, and make the attack function work with the current weapon of the player
    public bool isAttacking = false;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        anim = GetComponentInChildren<Animator>();
    }

    private void LateUpdate()
    {
        
    }

    public void Attack()
    {
        //Must do a check for isInteracting , that way we dont interrupt animations
        if (inputManager.attackInput) { isAttacking = true; } else { isAttacking = false; }
        if (isAttacking)
        {
            if (anim.GetFloat("XInput") == 1 || anim.GetFloat("YInput") == 1 || (anim.GetFloat("XInput") == 0 && anim.GetFloat("YInput") == 0)) 
            {
                anim.Play(weapon.basicAttack_R);
                //lastAttack = weapon.attackAnimation;
            }
            else if (anim.GetFloat("XInput") == -1 || anim.GetFloat("YInput") == -1)
            {
                anim.Play(weapon.basicAttack_L);
                //lastAttack = weapon.attackAnimation;
            }


        }
        
    }
}
