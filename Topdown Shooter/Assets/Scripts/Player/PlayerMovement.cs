using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 10f;
    bool isSprinting = false;

    [Header("References")]
    Rigidbody2D rb;
    PlayerController inputActions;
    Vector2 movement;

    [Header("Mouse Settings")]
    [SerializeField] Camera cam;
    Vector2 mousePos;

    void Awake()
    {
        inputActions = new PlayerController();
        rb = GetComponent<Rigidbody2D>();

        MovementCalling();
        SprintCalling();
    }

    void MovementCalling()
    {
        inputActions.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => movement = Vector2.zero;
    }

    void SprintCalling()
    {
        inputActions.Player.Sprint.performed += ctx => isSprinting = true;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }


    void OnDisable()
    {
        inputActions.Player.Disable();
    }


    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if(isSprinting)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 5f;
        }

        Vector2 move = (rb.position + movement * speed * Time.fixedDeltaTime);
        rb.MovePosition(move);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
} 