using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bagetaPrefab;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;  // Odkaz na Animator

    private Vector2 moveInput;
    private bool isKicking = false;
    private bool canShoot = true;

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
        
        if (Input.GetKeyDown(KeyCode.Q) && canShoot)
        {
            ShootBageta();
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
    
    void ShootBageta()
    {
        if (bagetaPrefab == null)
        {
            Debug.LogError("Bageta prefab is null! Please assign it in the inspector.");
            return; // Ukončí funkci, pokud je prefab null
        }
        // Vytvoření bagety na pozici hráče
        GameObject bageta = Instantiate(bagetaPrefab, transform.position, Quaternion.identity);
        // Nastavení směru bagety
        bageta.transform.localScale = new Vector3(transform.localScale.x, 1, 1); // Otočení bagety podle směru hráče

        canShoot = false; // Nastavit, že hráč nemůže střílet, dokud se předchozí bageta zničí

        // Znič bagetu po 3 sekundách a povol vystřelování
        Destroy(bageta, 3f); 
        Invoke("ResetShooting", 0.5f); // Přidej časový interval, během kterého hráč nemůže střílet
    }
    
    void ResetShooting()
    {
        canShoot = true; // Umožni znovu střílet
    }
}