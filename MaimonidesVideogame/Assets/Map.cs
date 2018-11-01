using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public MapCharacter mapCharacter_to_instantiate;
	public MapCharacter mapEnemy_to_instantiate;

	public Vector2 worldSize;
	public Vector2 mapSize;

	public MapCharacter mapCharacter;
	public List<MapCharacter> mapEnemy;
	public Character realCharacter;
	public List<Enemy> realEnemy;

	void Start()
	{
		mapCharacter = Instantiate (mapCharacter_to_instantiate);
		mapCharacter.character = realCharacter.gameObject;
		mapCharacter.transform.SetParent (transform);

		Events.OnAddEnemy += OnAddEnemy;
	}
	void OnDestroy()
	{
		Events.OnAddEnemy -= OnAddEnemy;
	}
	void OnAddEnemy(Transform t)
	{
		MapCharacter mapCharacter = Instantiate (mapEnemy_to_instantiate);
		mapCharacter.character = t.gameObject;
		mapCharacter.transform.SetParent (transform);
		mapEnemy.Add (mapCharacter);
	}

	void Update () {
		mapCharacter.transform.localPosition = GetMapPosition(mapCharacter.character.transform.position);
		MapCharacter mapCharacterToDestroy = null;
		foreach (MapCharacter enemyMapCharacter in mapEnemy) {
			if (enemyMapCharacter.character == null) {
				mapCharacterToDestroy = enemyMapCharacter;
			} else {
				enemyMapCharacter.transform.localPosition = GetMapPosition (enemyMapCharacter.character.transform.position);
			}
		}
		if (mapCharacterToDestroy != null) {
			mapEnemy.Remove (mapCharacterToDestroy);
			Destroy (mapCharacterToDestroy.gameObject);
		}

	}
	Vector2 GetMapPosition(Vector3 pos)
	{
		Vector2 newPos = new Vector2 ();
		newPos.x = (pos.x * mapSize.x) / worldSize.x;
		newPos.y = (pos.z * mapSize.y) / worldSize.y;
		return newPos;
	}
}
