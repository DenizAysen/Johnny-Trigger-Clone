using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRagdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Rigidbody[] rigidbodies;
    [SerializeField] private float ragdollForce;
    void Start()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = true;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ragdollify()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;

            rb.AddForce((Vector3.up + Random.insideUnitSphere) * ragdollForce);
        }

        animator.enabled = false;
        mainCollider.enabled = false;
    }
}
