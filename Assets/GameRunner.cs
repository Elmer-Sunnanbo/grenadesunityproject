using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Enemy;
    List<GameObject> Enemies = new List<GameObject>();
    void Start()
    {
        ResetEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ResetEnemies();
        }
    }

    void ResetEnemies()
    {
        Genocide();
        Repopulation();
    }

    void Genocide()
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            Destroy(Enemies[i]);
        }
    }
    void Repopulation()
    {
        Enemies.Add(Instantiate(Enemy, new Vector2(1, -3), Quaternion.identity));
        Enemies.Add(Instantiate(Enemy, new Vector2(-8, -3), Quaternion.identity));
        Enemies.Add(Instantiate(Enemy, new Vector2(5, -1), Quaternion.identity));
        Enemies.Add(Instantiate(Enemy, new Vector2(9, -3), Quaternion.identity));
    }
}
