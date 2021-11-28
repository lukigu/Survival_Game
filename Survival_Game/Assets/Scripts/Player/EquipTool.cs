using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    //components
    private Animator anim;
    private Camera cam;

    private void Awake()
    {
        //get our components
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    public override void OnAltAttackInput()
    {
        if(!attacking)
        {
            attacking = true;
            anim.SetTrigger("Attack");
            Invoke("OnCanAttack", attackRate);
        }
    }

    void OnCanAttack()
    {
        attacking = true;
    }

    public void OnHit()
    {

    }
}
