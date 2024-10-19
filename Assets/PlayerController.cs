using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;  // Odkaz na Animator

    private Vector2 moveInput;
    private bool isKicking = false;

    void Update()
    {
        // Získání vstupu
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Kontrola, zda se postava pohybuje, a nastavení animací dle směru
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetFloat("Speed", moveInput.sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        // Kontrola kopání
        if (Input.GetKeyDown(KeyCode.E) && !isKicking)
        {
            isKicking = true;
            animator.SetBool("isKicking", true);  // Nastavení proměnné v animátoru
            TriggerKick();
        }
    }

    void FixedUpdate()
    {
        // Pohyb pouze pokud postava nekopá
        if (!isKicking)
        {
            rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    void TriggerKick()
    {
        // Nastavení zpoždění kopání
        Invoke("StopKicking", 0.5f); 
    }

    void StopKicking()
    {
        isKicking = false;
        animator.SetBool("isKicking", false);  // Zpět na false, když kopání skončí
    }
}