using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody;

    private int speed = Animator.StringToHash("Speed");
    private float magnitude;

    private void Update()
    {
        magnitude = (rigidbody.velocity.normalized).magnitude;
        animator.SetFloat(speed, magnitude, Time.deltaTime, Time.deltaTime);
    }

}
