using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject prefab;           // 要生成的预制体
    public int numberOfPrefabs = 10;    // 生成的预制体数量
    public float startX = -20f;         // X 轴起始位置
    public float endX = 20f;            // X 轴结束位置
    public float yPosition = 0f;        // Y 轴位置

    void Start()
    {
        Prefabutility.SpawnPrefabs(prefab,numberOfPrefabs,startX,endX,yPosition);
    }

    
}
