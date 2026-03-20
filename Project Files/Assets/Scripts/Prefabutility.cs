using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefabutility
{
    public static void SpawnPrefabs(GameObject prefab, int numberOfPrefabs, float startX, float endX, float yPosition)
    {
        // Calculate the spacing between each prefab
        float spacing = (endX - startX) / (numberOfPrefabs - 1);

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Calculate the X position for each prefab
            float xPosition = startX + i * spacing;

            // Instantiate the prefab at the calculated position
            Object.Instantiate(prefab, new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
        }
    }
}
