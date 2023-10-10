using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    // InputSystem
    //private PlayerControl controls;
    private InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = moveInput * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
