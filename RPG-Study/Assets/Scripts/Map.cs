using System.Collections.Generic;
using UnityEngine;

public class MapRender : MonoBehaviour
{
    private int[,] map;
    [SerializeField] private List<GameObject> mapTiles;

    void Start()
    {
        InitMap();
        Render();
    }

    private void InitMap()
    {
        int w = 13;
        int h = 13;
        map = new int[w, h];
        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                if(i == 0 || j == 0 || i == h || j == w)
                {
                    map[i,j] = 0;
                }
                else
                {
                    map[i,j] = 1;
                }
            }
        }
    }

    private void Render()
    {
        int w = 13;
        int h = 13;

        float offset = 0.16f;

        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                GameObject go = Instantiate(mapTiles[0]);
                    go.transform.position = new Vector3(
                        -0.16f + (j*offset),
                        0.96f - (i*offset),
                        0
                    );
                
            }
        }
    }
}
