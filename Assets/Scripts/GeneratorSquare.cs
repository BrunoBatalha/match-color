using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorSquare : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;

    [SerializeField]
    private Transform spawnPointInitial;

    [SerializeField]
    private Transform destroyerPoint;

    [SerializeField]
    private float velocitySquares;

    private List<GameObject> squares;

    private void Awake()
    {
        squares = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (squares.Count == 0 || squares.Last().transform.position.x > spawnPointInitial.transform.position.x)
        {
            SpawnSquare();
        }

        DestroySquares();
    }

    private void SpawnSquare()
    {
        if (squares.Any())
        {
            GameObject lastSquare = squares.Last();
            float widthSquare = lastSquare.GetComponent<SpriteRenderer>().bounds.size.x;

            CreateSquare(new Vector2(lastSquare.transform.position.x - widthSquare, lastSquare.transform.position.y));
        }
        else
        {
            CreateSquare(new Vector2(spawnPointInitial.position.x, spawnPointInitial.position.y));
        }
    }

    private void DestroySquares()
    {
        var squaresToDestroy = squares.Where(s => s.transform.position.x > destroyerPoint.position.x).ToList();
        foreach (var square in squaresToDestroy)
        {
            squares.Remove(square);
            Destroy(square);
        }
    }

    private void CreateSquare(Vector2 vector2)
    {
        GameObject squareInstantiate = Instantiate(squarePrefab, vector2, Quaternion.identity);
        squareInstantiate.GetComponent<Square>().velocity = velocitySquares;
        squares.Add(squareInstantiate);
    }
}
