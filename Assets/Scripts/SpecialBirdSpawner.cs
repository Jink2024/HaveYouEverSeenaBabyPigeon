using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBirdSpawner : TimedObjectPlacer
{
    public GameObject RealPigeonPrefab;
    public GameObject PenguinPrefab;
    public GameObject HummingbirdPrefab;
    public GameObject OstrichPrefab;
    public GameObject GoosePrefab;
    
    private List<GameObject> AvailableSpecialBirdPrefabs = new();
    
    public void Start()
    {
        minimumSecondsToWait = GameParameters.BirdsMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BirdsMaximumSecondsToWait;
        
        AvailableSpecialBirdPrefabs.Add(RealPigeonPrefab);
        AvailableSpecialBirdPrefabs.Add(PenguinPrefab);
        AvailableSpecialBirdPrefabs.Add(HummingbirdPrefab);
        AvailableSpecialBirdPrefabs.Add(OstrichPrefab);
        AvailableSpecialBirdPrefabs.Add(GoosePrefab);
    }

    public override void Update()
    {
        if (!isActive)
            return;
        if (isOkToCreate && AvailableSpecialBirdPrefabs.Count > 0)
        {
            Prefab = ChooseRandomSpecialBirdPrefab();
            countdownCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }
    
    public override IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        SpecialBirdPlaceSelector();
        
        isOkToCreate = true;
    }

    private void SpecialBirdPlaceSelector()
    {
        if (Prefab == RealPigeonPrefab) Place();
        else if (Prefab == PenguinPrefab) PenguinPlace();
        else if (Prefab == HummingbirdPrefab) Place();
        else if (Prefab == OstrichPrefab) OstrichPlace();
        else if (Prefab == GoosePrefab) GoosePlace();
    }

    private void OstrichPlace()
    {
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }

    private void PenguinPlace()
    {
        Instantiate(Prefab, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)), Quaternion.identity);
    }

    private void GoosePlace()
    { 
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }

    public void UpdateAvailableSpecialBirds(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                AvailableSpecialBirdPrefabs.Add(RealPigeonPrefab);
                break;
            case 2:
                AvailableSpecialBirdPrefabs.Add(PenguinPrefab);
                break;
            case 3:
                AvailableSpecialBirdPrefabs.Add(HummingbirdPrefab);
                break;
            case 4:
                AvailableSpecialBirdPrefabs.Add(OstrichPrefab);
                break;
            case 5:
                 AvailableSpecialBirdPrefabs.Add(GoosePrefab);
                 break;
            default:
                AvailableSpecialBirdPrefabs.Clear();
                break;
        }
    }

    private GameObject ChooseRandomSpecialBirdPrefab()
    {
        int randomPrefabNumber = Random.Range(0, AvailableSpecialBirdPrefabs.Count);
        return AvailableSpecialBirdPrefabs[randomPrefabNumber];
    }
}
