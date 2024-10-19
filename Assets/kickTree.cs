using UnityEngine;

public class TreeKick : MonoBehaviour
{
    private Animator animator; // Reference na Animator
    public Transform player; // Reference na hráče
    public float kickDistance = 1f; // Maximální vzdálenost pro kopnutí

    void Start()
    {
        animator = GetComponent<Animator>(); // Získání reference na Animator komponentu stromu
    }

    void Update()
    {
        // Vypočítání vzdálenosti mezi stromem a hráčem
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // Pokud je hráč příliš blízko stromu
        if (distanceToPlayer < kickDistance)
        {
            // Pokud hráč stiskne klávesu "E"
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("isKicking", true);
            }
        }
        else
        {
            // Když je hráč daleko, resetujeme animaci
            animator.SetBool("isKicking", false);
        }
    }
}