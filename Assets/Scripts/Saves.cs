using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Saves 
{
    public PlayerSaveData player;
    public List<EnemySaveData> enemy;
}

[Serializable]
public class PlayerSaveData
{
    public Vector3 playerPos;
    public Vector3 playerRotation;
}

[Serializable]
public class EnemySaveData
{
    public Vector3 enemyPos;
    public Vector3 direction;
}

