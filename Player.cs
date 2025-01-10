using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public bool isJump = false;
    public bool isLive = true;

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
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump && isLive && GameManager.instance.gameScore >= 1) {
            PerformJump();
            //rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //anim.SetBool("isJump", true);
            //sfxPlayer.clip = sfxClip[0];
            //sfxPlayer.Play();
            //sfxPlayer.PlayOneShot(sfxClip[0]);
            //isJump = true;
        }
    }

    void PerformJump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("isJump", true);
        isJump = true;
        sfxPlayer.PlayOneShot(sfxClip[0]);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") && isJump && isLive) {
            HandleLanding();
            //anim.SetBool("isJump", false);
            //sfxPlayer.clip = sfxClip[1];
            //sfxPlayer.Play();
            //sfxPlayer.PlayOneShot(sfxClip[1]);
            //isJump = false;
        }
    }

    void HandleLanding()
    {
        anim.SetBool("isJump", false);
        isJump = false;
        sfxPlayer.PlayOneShot(sfxClip[1]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDie();
    }

    void PlayerDie()
    {
        anim.SetTrigger("doDie");
        sfxPlayer.PlayOneShot(sfxClip[2]);
        rigid.simulated = false;
        isLive = false;
    }
}
