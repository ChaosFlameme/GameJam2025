using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public int blocksPerRow = 10;      // Number of blocks per row
    public float startX = -24f;        // Starting X position for spawning
    public float endX = 24f;           // Ending X position for spawning
    public float startY = -1f;         // Starting Y position for the first row
    public float rowHeight = 1.5f;

    void Start()
    {
        SpawnBlocks();
        SpawnBlocksRverse();
    }

    void SpawnBlocks()
    {
        for (int lv = 0; lv < blockPrefabs.Length; lv++)
        {
            float yPosition = startY - (lv * rowHeight);
            Prefabutility.SpawnPrefabs(blockPrefabs[lv], blocksPerRow, startX, endX, yPosition);
            if (lv == blockPrefabs.Length - 1)
            {
                yPosition = startY - ((lv+1) * rowHeight);
                Prefabutility.SpawnPrefabs(blockPrefabs[lv], blocksPerRow, startX, endX, yPosition);
            }
        }
    }

    void SpawnBlocksRverse(){
        for (int lv = 0; lv < blockPrefabs.Length; lv++)
        {
            float yPosition = -startY + (lv * rowHeight);
            Prefabutility.SpawnPrefabs(blockPrefabs[lv], blocksPerRow, startX, endX, yPosition);
            if (lv == blockPrefabs.Length - 1)
            {
                yPosition = -startY + ((lv+1) * rowHeight);
                Prefabutility.SpawnPrefabs(blockPrefabs[lv], blocksPerRow, startX, endX, yPosition);
            }
        }
    }

    /*
    void SpawnBlocks()
    {
        int index = 0;
        for (int lv = 0; lv < blockPrefabs.Length*2-1; lv++)
        {
            float yPosition = startY - (lv * rowHeight);
            if (index != 0)
            {
                Prefabutility.SpawnPrefabs(blockPrefabs[index], blocksPerRow, startX, endX, yPosition);
                lv++;
            }
            yPosition = startY - (lv * rowHeight);
            Prefabutility.SpawnPrefabs(blockPrefabs[index], blocksPerRow, startX, endX, yPosition);
            index++;
        }
    }

    void SpawnBlocksRverse(){
        int index = 0;
        for (int lv = 0; lv < blockPrefabs.Length*2-1; lv++)
        {
            float yPosition = -startY + (lv * rowHeight);
            if (index != 0)
            {
                Prefabutility.SpawnPrefabs(blockPrefabs[index], blocksPerRow, startX, endX, yPosition);
                lv++;
            }
            yPosition = -startY + (lv * rowHeight);
            Prefabutility.SpawnPrefabs(blockPrefabs[index], blocksPerRow, startX, endX, yPosition);
            index++;
        }
    }
    */
}
