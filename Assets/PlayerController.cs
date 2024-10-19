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

        // Nastavení animací pro pohyb (animátor aktualizuje pohyb na základě směru a rychlosti)
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

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
        Invoke("StopKicking", 0.5f);  // Časový úsek pro kopnutí (např. 0.5s)
    }

    void StopKicking()
    {
        isKicking = false;
        animator.SetBool("isKicking", false);  // Zpět na false, když kopání skončí
    }
}