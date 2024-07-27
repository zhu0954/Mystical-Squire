using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float cooldown = 100f;
    private Transform player;
    private Rigidbody2D rb;
    private PlayerStats P;



    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            P = playerObject.GetComponent<PlayerStats>();
        }

    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(cooldown < 0)
            {
            P.playerHealth-=10;
            Debug.Log("ow");
            cooldown = 1;
            }
        }
    }
      void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(cooldown < 0)
            {
            P.playerHealth-=10;
            Debug.Log("owie");
            cooldown = 1;
            }
        }
    }
}
