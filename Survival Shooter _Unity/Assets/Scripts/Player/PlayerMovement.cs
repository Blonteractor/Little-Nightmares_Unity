using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public Transform rayFloor;
    public Camera main;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;

    private int floorMask;
    private float camRayLength;

    private void Awake()
    {
        camRayLength = Vector3.Distance(transform.position, rayFloor.position);
        floorMask = LayerMask.GetMask("Invisible");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Animating(h, v);
        Turning();
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, 10000f, floorMask))
        {

            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
                
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;

        anim.SetBool("isWalking", walking);
    }
}
    