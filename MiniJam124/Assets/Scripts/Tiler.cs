using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private List<Tile> OrderedTiles;
    private int _index = 0;

    public void OnLastThresholdReached()
    {
        var position = AggregateTileWidth(_index);
        var next = Instantiate(OrderedTiles[_index]);
    }

    private float AggregateTileWidth(int index)
    {
        var agg = 0f;
        for (var i = 0; i < Mathf.Min(
                 index, OrderedTiles.Count); i++)
        {
            agg += OrderedTiles[i].WidthZ;
        }

        return agg;
    }
}
