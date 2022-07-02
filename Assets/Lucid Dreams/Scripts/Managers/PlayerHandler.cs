using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHandler : MonoBehaviour
{
    [Header("References")]
    PlayerAnimatorManager playerAnimatorManager;

    [Header("Bools")]
    public bool isInteracting;

    private void Awake()
    {
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }

    private void Update()
    {
        isInteracting = playerAnimatorManager.anim.GetBool("isInteracting");
    }
}

