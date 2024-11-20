using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed = 1.0f;
    public float turnSpeed = 100.0f;
    public Animator animator;
    private Vector3 prevPosition;
    private float velocity;
    public BehaviorMinion behavior;
    public GameObject home;
    private float moveTime;

    public string walkForwardAnimation = "walk_forward";
    public string runForwardAnimation = "run_forward";
    public string trotAnimation = "trot_forward";
    public string idleAnimation = "idle";

    // Start is called before the first frame update
    void Start()
    {
        prevPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) 
        {
            // forward
            Vector3 fwd = transform.forward;
            CharacterController controller = GetComponent<CharacterController>();
            controller.Move(fwd * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            // backward
            Vector3 bwd = -transform.forward;
            CharacterController controller = GetComponent<CharacterController>();
            controller.Move(bwd * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            // turn left
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            // turn right
            Vector3 right = transform.right;
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        
        velocity = Vector3.Distance(transform.position, prevPosition) / Time.deltaTime;
        prevPosition = transform.position;

        animator.SetFloat("Velocity", velocity);

        if (velocity == 0.0f) 
        {
            animator.Play(idleAnimation);
            moveTime = 0.0f;
        }
        else if (moveTime > 0.0f && moveTime < 1.5f) 
        {
            velocity = 1.0f;
            animator.Play(walkForwardAnimation);
        }
        else if (moveTime > 1.5f && moveTime < 3.0f) 
        {
            velocity = 2.0f;
            animator.Play(trotAnimation);
        }
        else if (moveTime > 3.0f) 
        {
            velocity = 3.0f;
            animator.Play(runForwardAnimation);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Home"))
        {
            Debug.Log("Entered home");
            behavior.isHome = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Home"))
        {
            Debug.Log("Exited home");
            behavior.isHome = false;
        }
    }
}
