using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 100.0f;
    public Animator animator;
    private Vector3 prevPosition;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            // forward
            Vector3 fwd = transform.forward;
            // transform.position += fwd * moveSpeed * Time.deltaTime;
            CharacterController controller = GetComponent<CharacterController>();
            controller.Move(fwd * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)) {
            // turn left
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) {
            // backward
            Vector3 bwd = -transform.forward;
            // transform.position += bwd * moveSpeed * Time.deltaTime;
            CharacterController controller = GetComponent<CharacterController>();
            controller.Move(bwd * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) {
            // turn right
            Vector3 right = transform.right;
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        velocity = Vector3.Distance(transform.position, prevPosition) / Time.deltaTime;
        prevPosition = transform.position;

        animator.SetFloat("Velocity", velocity);

        // make character idle if velocity = 0
        if (velocity < 0.1f) {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsTrotting", false);
        }
        else if (velocity < 1.0f && velocity >= 0.1f) {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsTrotting", false);
        }
        else if (velocity >= 1.0f && velocity < 2.0f) {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsTrotting", true);
        }
        else if (velocity >= 2.0f) {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsTrotting", false);
        }
    }
}
