using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb2d;

    public int speed;
    [HideInInspector]
    public bool jump;

    public SpriteRenderer chestRenderer;
    public Sprite newChest;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (jump == false)
            {
                StartCoroutine(Jump());
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
    }

    void ChangeSprite()
    {
        chestRenderer.sprite = newChest;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chest")
        {
            ChangeSprite();
        }
    }

    IEnumerator Jump()
    {
        jump = true;

        for (int i = 0; i < 10; i++)
        {
            rb2d.AddForce((Vector2.up * 20));
        }

        yield return new WaitForSeconds(1);

        jump = false;

        yield return null;
    }
}
