using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
	[SerializeField] Tilemap map;
	[SerializeField] List<TileData> tileDataList;
	Dictionary<TileBase, TileData> dataFromTiles;

	private void Awake()
	{
		dataFromTiles = new Dictionary<TileBase, TileData>();

		foreach (TileData tileData in tileDataList)
		{
			foreach (TileBase tile in tileData.tiles)
			{
				dataFromTiles.Add(tile, tileData);
			}
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int gridPosition = map.WorldToCell(mousePosition);

			TileBase clickedTile = map.GetTile(gridPosition);

			float duration = dataFromTiles[clickedTile].duration;
			float flammability = dataFromTiles[clickedTile].flammability;
			TileStatus tileStatus = dataFromTiles[clickedTile].tileStatus;

			Debug.Log("tiledata at " + gridPosition + " flammability: " + flammability + " duration: " + duration + " tileStatus: " + tileStatus);
		}
	}
}
