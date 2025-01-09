using UnityEngine;

public class Cactus : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Collider2D coll;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    void Update ()
    {
        UpdateCactusState();
    }

    void UpdateCactusState()
    {
        if  (transform.position.x < -12) {
            bool shouldActivate = Random.Range(0, 2) == 1;

            spriteRenderer.enabled = shouldActivate;
            coll.enabled = shouldActivate;
        }

        /*
        if (Random.Range(0, 2) == 1 && transform.position.x < -12) {
            spriteRenderer.enabled = true;
            coll.enabled = true;
        }
        else if (Random.Range(0, 2) == 0 && transform.position.x < -12) {
            spriteRenderer.enabled = false;
            coll.enabled = false;
        } */
    }
}
