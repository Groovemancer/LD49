using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    private static WorldGenerator _instance;

    public int width = 20;
    public int height = 10;

    public int blobbiesMax = 10;
    public int blobbies = 0;

    public bool[,] blobbyPresent;

    public GameObject blobbyPrefab;

    public GameObject wallTilePrefab;

    void Awake()
    {
        _instance = this;
    }

    public static WorldGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("WorldGenerator").AddComponent<WorldGenerator>();

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        blobbyPresent = new bool[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                blobbyPresent[x, y] = false;

                if (x == 0 || x == (width - 1) ||
                    y == 0 || y == (height - 1))
                {
                    GameObject wallGO = GameObject.Instantiate(wallTilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                    wallGO.transform.SetParent(this.gameObject.transform);
                }
            }
        }

        while (blobbies < blobbiesMax)
        {
            int x = Random.Range(1, width - 1);
            int y = Random.Range(1, height - 1);

            if (!blobbyPresent[x, y])
            {
                blobbyPresent[x, y] = true;
                GameObject blobbyGO = GameObject.Instantiate(blobbyPrefab, new Vector3(x, y, 0), Quaternion.identity);
                blobbyGO.transform.SetParent(this.gameObject.transform);
                blobbies++;
            }
        }

        GameManager.Instance.SetMaxPoints(blobbies);

        this.transform.position = new Vector3(-width / 2, -height / 2, 0);
    }
}
