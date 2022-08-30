using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveProgress : MonoBehaviour
{
    Saves saves;
    PlayerMove player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("1try save");
            SaveCurrentProgress();
        }
    }

    public void SaveCurrentProgress()
    {
        Debug.Log("try save");
        player = FindObjectOfType<PlayerMove>();
        saves = new Saves();
        saves.player.playerPos = player.transform.position;
        saves.player.playerRotation = player.transform.rotation.eulerAngles;
        EnemyMoving[] enemys = FindObjectsOfType<EnemyMoving>();
        foreach (var item in enemys)
        {
            EnemySaveData enemy = new EnemySaveData();
            enemy.enemyPos = item.transform.position;
            enemy.direction = item.Direction();
            saves.enemy.Add(enemy);
        }

        
        File.WriteAllText("/Saves/save.json", JsonUtility.ToJson(saves));
        
    }

    private void LoadFlomFile()
    {

    }
}
