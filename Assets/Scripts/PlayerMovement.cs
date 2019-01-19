using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector3 movement;
    private Animator animator;

    public PlayerState CurrentState;
    public float MovementSpeed;

    public List<AudioClip> SwordSwings;

    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Submit") && CurrentState == PlayerState.Walking)
        {
            StartCoroutine(Attack());
        }
        else if (CurrentState == PlayerState.Walking)
        {
            AnimateAndMove(movement);
        }
    }

    private IEnumerator Attack()
    {
        var swordSwingSound = GetRandomSwordSwingSound();
        //if (swordSwingSound != null) Util.PlaySound(swordSwingSound);
        if (swordSwingSound != null) AudioSource.PlayClipAtPoint(swordSwingSound, transform.position);

        //set state to attacking for just one frame to change animation
        animator.SetBool("IsAttacking", true);
        CurrentState = PlayerState.Attacking;
        yield return null;

        //wait for duration of attack animation
        animator.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(0.25f);

        CurrentState = PlayerState.Walking;
    }

    private AudioClip GetRandomSwordSwingSound()
    {
        if (SwordSwings == null || SwordSwings.Count == 0)
        {
            Debug.LogAssertion("No sword swing sounds specified in inspector.");
            return null;
        }
        return SwordSwings[Random.Range(0, SwordSwings.Count)];
    }

    private void AnimateAndMove(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            animator.SetBool("IsMoving", true);

            Vector2 newPosition = transform.position + (movement * MovementSpeed * Time.fixedDeltaTime);
            body.MovePosition(Util.PixelClamp(newPosition));
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void StopAnimations()
    {
        animator.SetBool("IsMoving", false);
    }
}