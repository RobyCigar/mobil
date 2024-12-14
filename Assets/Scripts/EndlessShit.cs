using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessShit : MonoBehaviour
{
    [SerializeField] private GameObject[] sectionPrefabs;

    private GameObject[] sectionsPool = new GameObject[20];
    private GameObject[] sections = new GameObject[10];

    private Transform playerCarTransform;

    private readonly WaitForSeconds waitFor100ms = new WaitForSeconds(0.1f);

    private const float sectionLength = 26f;


    private void Start()
    {
        // Find the player's transform
        playerCarTransform = GameObject.FindGameObjectWithTag("Player").transform;

        int prefabIndex = 0;

        // Initialize the pool for endless sections
        for (int i = 0; i < sectionsPool.Length; i++)
        {
            sectionsPool[i] = Instantiate(sectionPrefabs[prefabIndex]);
            sectionsPool[i].SetActive(false);

            prefabIndex++;

            // Loop prefab index if we run out of prefabs
            if (prefabIndex >= sectionPrefabs.Length)
            {
                prefabIndex = 0;
            }
        }

        for (int i = 0; i < sections.Length; i++) {
            GameObject randomSection = GetRandomSectionFromPool();
            randomSection.transform.position = new Vector3(sectionsPool[i].transform.position.x, 0, i * sectionLength);
            randomSection.SetActive(true);
            sections[i] = randomSection;
        }

        StartCoroutine(UpdateLessOften());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator UpdateLessOften()
    {
        while (true)
        {
            UpdateSectionPositions();
            yield return new WaitForSeconds(0.1f); // Wait for 100ms
        }
    }

    private void UpdateSectionPositions()
    {
        for (int i = 0; i < sections.Length; i++)
        {
            // Check if the section is too far behind the player
            if (sections[i].transform.position.z < playerCarTransform.position.z - sectionLength)
            {
                // Store the last section's position and deactivate the current section
                Vector3 lastSectionPosition = sections[i].transform.position;
                sections[i].SetActive(false);

                // Get a new section from the pool
                sections[i] = GetRandomSectionFromPool();

                // Move the new section into place and activate it
                sections[i].transform.position = new Vector3(
                    lastSectionPosition.x,
                    0,
                    lastSectionPosition.z + sectionLength * sections.Length
                );
                sections[i].SetActive(true);
            }
        }
    }

    GameObject GetRandomSectionFromPool() 
    {
        int randomIndex = Random.Range(0, sectionsPool.Length);
        bool isNewSectionFound = false;

        while(!isNewSectionFound) 
        {
            if(!sectionsPool[randomIndex].activeInHierarchy) {
                isNewSectionFound = true;
            } else {
                randomIndex++;
            }
        }

        return sectionsPool[randomIndex];
    }
}
