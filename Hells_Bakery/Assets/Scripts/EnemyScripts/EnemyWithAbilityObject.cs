using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/EnemyWithAbility")]
public class EnemyWithAbilityObject : EnemyObject
{
    public bool hasAbility = true;
    public GameObject enemyToSpawn;
    public EnemyObject enemyToSpawnObject;

}
