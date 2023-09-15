using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScriptCollider : MonoBehaviour
{
    [SerializeField] Tile tile;

    void Start()
    {
        tile.colliderType = Tile.ColliderType.Sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
