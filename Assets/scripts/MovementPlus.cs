using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Definiuje jaki inny komponenent jest obowi?zkowy dla poprawnego dzia?ania tego skryptu
//1. Nie b?dzie mo?liwo?ci usun?? ten komponent z gameObject'u
//2. Je?li nie by? dodany r?cznie, to b?dzie dodany automatycznie
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
public class MovementPlus : MonoBehaviour
{
    //W?asciwo?ci prywatne nie s? widoczne w innych komponentach i w inspektorze
    private Rigidbody2D rb;
    private Animator anim;

    public float upForce = 200;
    public float speed = 300;
    public float runSpeed = 600;

    private bool isGrounded = false;

    //Pomocnicze w?asciwo?ci do przekazania warto?ci input z metody Update do metody FixedUpdate
    private bool isSprint = false;
    private float moveVector = 0;
    private bool isJumping = false;

    void Start()
    {
        //Automatyczne odzyskiwanie potrzebnych komponentów w gameObject'ie 
        //Ne potrzebujemy to konfigurowa? w inspektorze
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //Metoda Update jest wywo?ana ka?d? klatke,
    //wi?c jest dobym miejscem do przeczytania danych wej?ciowych oraz wywo?ania animatora
    void Update()
    {

        moveVector = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = true;
        }
        else 
        {
            isSprint = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }

    }

    //Metoda FixedUpdate jest wywo?ana niezale?nie od FPS, - jest u?ywana do precyzyjnego obliczenia fizyki
    private void FixedUpdate()
    {
        float moveStep = moveVector;
        if (isSprint)
        {
            moveStep *= runSpeed * Time.deltaTime;
        }
        else 
        {
            moveStep *= speed * Time.deltaTime;
        }

        rb.velocity = new Vector2(moveStep,rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
