using UnityEngine;

public class BagetaController : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        // Znič bagetu po 3 sekundách
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Zjisti, zda je bageta aktivní
        if (gameObject.activeInHierarchy)
        {
            // Posuň bagetu vpřed
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Zde můžeš přidat logiku pro interakci s nepřáteli
        // Pokud narazí na objekt, znič bagetu
        Destroy(gameObject);
    }
}