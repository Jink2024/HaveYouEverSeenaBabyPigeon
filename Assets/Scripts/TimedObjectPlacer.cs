using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public float minimumSecondsToWait;
    public float maximumSecondsToWait;
    
    private bool isOkToCreate = true;
    public bool isActive = true; // Change if we want to use StartPlacing
    private Coroutine countdownCoroutine;
    public Game Game;
    void Update()
    {
        //if (Game.isGameRunning == false)
            //return;
        if (!isActive)
            return;
        if (isOkToCreate)
        {
            countdownCoroutine = StartCoroutine(CoundownUntilCreation());
        }
    }
    
    public void StartPlacing()
    {
        isActive = true;
        isOkToCreate = true;
    }
    
    public void StopPlacing()
    {
        isActive = false;
        isOkToCreate = false;
        
        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);

        CleanupPlacerObjects();
    }

    private void CleanupPlacerObjects()
    {
        List<GameObject> placedObjects = GameObject.FindGameObjectsWithTag(Prefab.tag).ToList();
        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }

    IEnumerator CoundownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        
        isOkToCreate = true;
    }

    public virtual void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
    
}
