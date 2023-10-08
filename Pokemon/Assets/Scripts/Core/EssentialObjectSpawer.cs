using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectSpawer: MonoBehaviour
{
    [SerializeField] GameObject essentialObjectPrefab;

    private void Awake()
    {
        
       var existingObjects = FindObjectsOfType<EssentialObject>();

        if (existingObjects.Length == 0)
        {
            //IF THERE IS A GRID, THEN SPAWN AT IT'S CENTER
            var spawnPos = new Vector3(0, 0, 0);

            var grid = FindObjectOfType<Grid>();
            if (grid != null)
                spawnPos = grid.transform.position;
            Instantiate(essentialObjectPrefab, spawnPos, Quaternion.identity);
        }
    }
}
