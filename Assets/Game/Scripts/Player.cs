using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ability primaryAbility;
    public Ability secondaryAbility;
    public Ability dashAbility;

    public static bool AbilityInUse;
    public static bool isDashing;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            isDashing = true;
            dashAbility.ActivateAbility();
        }

        if (Input.GetKey(KeyCode.Mouse1) && !isDashing)
            secondaryAbility.ActivateAbility();
         if (Input.GetKey(KeyCode.Mouse0) && !isDashing)
            primaryAbility.ActivateAbility();
    }

    public void ResetAbilities()
    {
        isDashing = false;
        secondaryAbility.ResetAbility();
        primaryAbility.ResetAbility();
        dashAbility.ResetAbility();
        AbilityInUse = false;
    }
}
