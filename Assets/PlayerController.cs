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
        // Získání horizontálního a vertikálního vstupu
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // Nastavení parametru Speed v Animatoru
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.magnitude); // Nastavení rychlosti
        
    }

    void FixedUpdate()
    {
        // Pohyb pouze pokud existuje vstup
        if (moveInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}