using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ability primaryAbility;
    public Ability secondaryAbility;

    public static bool AbilityInUse;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
            secondaryAbility.ActivateAbility();
        else if (Input.GetKey(KeyCode.Mouse0))
            primaryAbility.ActivateAbility();
    }

    public void ResetAbilities()
    {
        secondaryAbility.ResetAbility();
        primaryAbility.ResetAbility();
        AbilityInUse = false;
    }
}
