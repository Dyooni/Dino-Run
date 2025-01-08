using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpForce;
    bool isJump;

    public AudioClip[] sfxClip;

    Rigidbody2D rigid;
    Animator anim;
    AudioSource sfxPlayer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sfxPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
            Jump();
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("isJump", true);
        sfxPlayer.clip = sfxClip[0];
        sfxPlayer.Play();
        isJump = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("isJump", false);
        sfxPlayer.clip = sfxClip[1];
        sfxPlayer.Play();
        isJump = false;
    }
}
