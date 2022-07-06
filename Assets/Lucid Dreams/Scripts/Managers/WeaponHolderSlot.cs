using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isLeftHandSlot;
    public bool isRightHandSlot;

    public Sprite currentWeaponSprite;

    //This function makes the current weapon not visible
    public void UnloadWeapon()
    {
        if(currentWeaponSprite != null)
        {
            spriteRenderer.gameObject.SetActive(false);
        }
    }

    public void UnloadWeaponAndDestroy()
    {
        if (currentWeaponSprite != null)
        {
            Destroy(currentWeaponSprite);
        }
    }

    public void LoadWeaponSprite(WeaponItem weaponItem)
    {


        if(weaponItem == null)
        {
            UnloadWeapon();
            return;
        }

        spriteRenderer.sprite = weaponItem.weaponSprite; //Here we are changing the current weapon sprite with the new weaponItem sprite

        currentWeaponSprite = spriteRenderer.sprite;
    }


}
