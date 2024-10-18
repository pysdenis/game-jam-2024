using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu
    private Rigidbody2D rb; // Reference na Rigidbody2D
    private Animator animator; // Reference na Animator

    private Vector2 moveInput; // Vstup pro pohyb

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal"); // Získání horizontálního vstupu
        moveInput.y = Input.GetAxis("Vertical");   // Získání vertikálního vstupu

        // Nastavení parametru Speed v Animatoru
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.magnitude); // Nastavení rychlosti
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}