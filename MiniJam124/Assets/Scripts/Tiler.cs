using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tiler : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _despawnDistance = 1f;
    [SerializeField] private int _tilesPrespawned = 10;
    [SerializeField] private float _baseMoveSpeed = 1f;
    [SerializeField] private List<Tile> _orderedTiles;

    public float MoveMultiplier { get; set; } = 1f;
    private int _index = 0;
    private readonly Queue<Tile> _spawnedTiles = new();

    private void Start()
    {
        // Temp, let game control this
        Begin();
    }
    
    private void Update()
    {
        MoveTiles();
    }

    private void MoveTiles()
    {
        var delta = Time.deltaTime * _baseMoveSpeed * MoveMultiplier;
        foreach (var spawnedTile in _spawnedTiles)
        {
            spawnedTile.transform.position += new Vector3(0f, 0f, -delta);
        }
    }

    public void Begin()
    {
        for (var i = 0; i < _tilesPrespawned; i++)
        {
            SpawnSegment();
        }
    }

    private void LastThresholdReached()
    {
        SpawnSegment();

        // Tiles will have to be anchored at their start
        // Otherwise, distance calculation will be incorrect
        if (_spawnedTiles.TryPeek(out var tile) &&
            tile.transform.position.z + tile.WidthZ < _startPosition.z - _despawnDistance)
        {
            Destroy(_spawnedTiles.Dequeue().gameObject);
        }

        if (_index == _orderedTiles.Count - 1)
        {
            Debug.Log("Done lol");
        }
    }

    private void SpawnSegment()
    {
        var index = Mathf.Min(_index, _orderedTiles.Count - 1);
        var position = _spawnedTiles.Count > 0 ? _spawnedTiles.Last().End : _startPosition;
        var next = Instantiate(_orderedTiles[index], _startPosition + position,
            Quaternion.identity);
        _spawnedTiles.Enqueue(next);
        next.OnThresholdReached += LastThresholdReached;
        _index++;
    }
}
