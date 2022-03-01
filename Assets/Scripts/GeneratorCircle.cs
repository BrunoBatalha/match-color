using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorCircle : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform spawnPointInitial;

    [SerializeField]
    private Transform destroyerPoint;

    private const int MAX_ENTITIES = 1;
    private List<GameObject> entities;

    private void Awake()
    {
        entities = new List<GameObject>();
    }


    // Start is called before the first frame update
    void Start()
    {
        SpawnEntity();
    }

    // Update is called once per frame
    void Update()
    {
        if (entities.Count < MAX_ENTITIES)
        {
            SpawnEntity();
        }

        DestroyEntities();
    }

    private void SpawnEntity()
    {
        GameObject entity = Instantiate(prefab, new Vector2(spawnPointInitial.position.x, spawnPointInitial.position.y), Quaternion.identity);
        entities.Add(entity);
    }

    private void DestroyEntities()
    {
        var entitiesToDestroy = entities.Where(s => s.transform.position.y > destroyerPoint.position.y).ToList();
        foreach (var entity in entitiesToDestroy)
        {
            entities.Remove(entity);
            Destroy(entity);
        }
    }
}
