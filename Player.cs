using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    bool isJump = false;

    public AudioClip[] sfxClip;
    AudioSource sfxPlayer;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sfxPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump) {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            sfxPlayer.clip = sfxClip[0];
            sfxPlayer.Play();
            isJump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" && isJump) {
            anim.SetBool("isJump", false);
            sfxPlayer.clip = sfxClip[1];
            sfxPlayer.Play();
            isJump = false;
        }
    }
}
