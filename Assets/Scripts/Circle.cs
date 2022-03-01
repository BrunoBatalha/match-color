using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = ColorsGame.GetRandomColor();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2d.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Square")
        {
            Color squareColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            Color circleColor = GetComponent<SpriteRenderer>().color;
            if (squareColor.ToString() == circleColor.ToString())
            {
                GameManager.instance.AddScore();
            }
            else
            {
                GameManager.instance.ShowGameOver();
            }
        }
    }
}
