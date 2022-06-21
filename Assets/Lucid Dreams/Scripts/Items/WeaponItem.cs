using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Items/Weapon Item")]
public class WeaponItem : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public string weaponDescription;

    [Header("Animations")]
    public string basicAttack_L;
    public string basicAttack_R;

    [Header("VFX's")]
    //

    [Header("SFX's")]
    public GameObject attackSFX;
}
