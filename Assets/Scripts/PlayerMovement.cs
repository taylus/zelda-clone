using UnityEngine;

namespace SpriteDemo
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D body;
        private Vector3 movement;
        private Animator animator;

        public float MovementSpeed;

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
        }

        public void FixedUpdate()
        {
            AnimateAndMove(movement);
        }

        private void AnimateAndMove(Vector3 movement)
        {
            if (movement != Vector3.zero)
            {
                animator.SetFloat("MoveX", movement.x);
                animator.SetFloat("MoveY", movement.y);
                animator.SetBool("IsMoving", true);
                body.MovePosition(transform.position + movement * MovementSpeed * Time.fixedDeltaTime);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }
}