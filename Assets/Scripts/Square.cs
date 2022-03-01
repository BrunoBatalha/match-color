using UnityEngine;

public class Square : MonoBehaviour
{
    [HideInInspector]
    public float velocity;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = ColorsGame.GetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * velocity);
    }   
}
