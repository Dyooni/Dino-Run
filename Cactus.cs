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

    public void SpawnCactus()
    {
        if (Random.Range(0, 2) == 1 && transform.position.x < -12) {
            spriteRenderer.enabled = true;
            coll.enabled = true;
        }
        else if (Random.Range(0, 2) == 0 && transform.position.x < -12) {
            spriteRenderer.enabled = false;
            coll.enabled = false;
        }
    }
}
