using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public int damage;

    [Space, Header("Animation Variables")]
    public int numberOfAbilityAnimations;
    public string abilityAnimationName;
    public GameObject[] slashes;

    int currentAbilityAnimation;
    Animator animator;

    private void Start()
    {
        animator = transform.root.GetComponent<Animator>();
        currentAbilityAnimation = 1;
    }

    public void ActivateAbility()
    {
        if (!Player.AbilityInUse)
        {
            print(abilityAnimationName + " Activated. " + abilityAnimationName + " " + currentAbilityAnimation + " used.");
            Player.AbilityInUse = true;
            animator.applyRootMotion = true;
            animator.SetInteger(abilityAnimationName, currentAbilityAnimation);

            if (currentAbilityAnimation < numberOfAbilityAnimations)
                currentAbilityAnimation++;
            else if (currentAbilityAnimation >= numberOfAbilityAnimations)
                currentAbilityAnimation = 1;
        }
    }

    public void ResetAbility()
    {
        animator.SetInteger(abilityAnimationName, 0);
        animator.applyRootMotion = false;
    }

    public void Slash(int attackNumber)
    {
        if(slashes[(attackNumber - 1)] != null)
            slashes[(attackNumber - 1)].SetActive(true);
    }
}
