using UnityEngine;

public class BakerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu (stejná jako hráčova)
    private float adjustedSpeed; // Upravená rychlost pekaře (o 1/4 pomalejší)
    public Rigidbody2D rb; // Reference na Rigidbody2D
    public Animator animator; // Reference na Animator

    private Vector2 moveDirection; // Směr pohybu
    public Transform player; // Reference na hráče

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        adjustedSpeed = moveSpeed * 0.75f; // Nastavení rychlosti o 1/4 pomalejší
    }

    void Update()
    {
        // Zjištění směru od hráče (pekař utíká opačným směrem)
        Vector2 directionToPlayer = transform.position - player.position;
        moveDirection = directionToPlayer.normalized;

        // Nastavení parametru Speed v Animatoru
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.magnitude);
    }

    void FixedUpdate()
    {
        // Pekař se pohybuje pouze pokud je hráč v jeho blízkosti
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < 10f) // Pekař začne utíkat, pokud je hráč blízko (lze upravit vzdálenost)
        {
            rb.MovePosition(rb.position + moveDirection * (adjustedSpeed * Time.fixedDeltaTime));
        }
    }
}