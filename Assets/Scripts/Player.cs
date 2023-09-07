using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputField inputField_PlayerName;
    private string playerName;

    [SerializeField]
    private float speed;
    private Vector2 moveDirection = Vector2.zero;
    private Vector3 mousePosition = Vector3.zero;

    [SerializeField]
    private Animator anim;

    private SpriteRenderer spriteRenderer;
    //private Rigidbody2D rigidbody;

    private void Awake()
    {
        playerName = inputField_PlayerName.GetComponent<InputField>().text;

        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        //rigidbody = GetComponent<Rigidbody2D>();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        moveDirection = moveVector.normalized;
        //Debug.Log("moveDirection: " + moveDirection);

        mousePosition = MousePosition();
    }

    private void Move()
    {
        // moveDirection.x이 0이면
        //if (moveDirection.x == 0)
        if (mousePosition.x == 0)
        {
            // 아무것도 하지 않는다.
        }
        // moveDirection.x이 양수이면
        //else if (moveDirection.x >= 1)
        else if (mousePosition.x >= 1)
        {
            // 플립 x = false
            spriteRenderer.flipX = false;
        }
        // moveDirection.x이 음수이면
        else
        {
            // 플립 x = true
            spriteRenderer.flipX = true;
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private Vector3 MousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //Debug.Log("MousePosition: " + point);
        return mousePosition;
    }
}
