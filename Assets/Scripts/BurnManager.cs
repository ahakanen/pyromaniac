using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BurnManager : MonoBehaviour
{
	[SerializeField] Tilemap hitpointsMap;
	Dictionary<Vector3Int, float> tileHitpoints = new Dictionary<Vector3Int, float>();
	[SerializeField] Color burnedColor = Color.black;

	public void ChangeHitpoints(Vector3Int gridPosition, float changeBy)
	{
		if (!tileHitpoints.ContainsKey(gridPosition))
		{
			TileBase tile = GameManager.Instance.mapManager.map.GetTile(gridPosition);
			SetHitpoints(gridPosition, GameManager.Instance.mapManager.dataFromTiles[tile].hp);
		}
		tileHitpoints[gridPosition] = tileHitpoints[gridPosition] + changeBy;
	}

	public void SetHitpoints(Vector3Int gridPosition, float SetTo)
	{
		tileHitpoints[gridPosition] = SetTo;
	}

	public float GetHitpoints(Vector3Int gridPosition)
	{
		if (!tileHitpoints.ContainsKey(gridPosition))
		{
			TileBase tile = GameManager.Instance.mapManager.map.GetTile(gridPosition);
			return(GameManager.Instance.mapManager.dataFromTiles[tile].hp);
		}
		return (tileHitpoints[gridPosition]);
	}

	public void VisualizeBurn()
	{
		foreach (var entry in tileHitpoints)
		{
			if (entry.Value <= 0f)
			{
				hitpointsMap.SetTileFlags(entry.Key, TileFlags.None);
				hitpointsMap.SetColor(entry.Key, burnedColor);
				hitpointsMap.SetTileFlags(entry.Key, TileFlags.LockColor);
			}
		}
	}
}
