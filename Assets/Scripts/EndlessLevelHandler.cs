using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelHandler : MonoBehaviour
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

        // Initialize the first active sections
        for (int i = 0; i < sections.Length; i++)
        {
            GameObject randomSection = GetRandomSectionFromPool();
            randomSection.transform.position = new Vector3(0, 0, i * sectionLength);
            randomSection.SetActive(true);
            sections[i] = randomSection;
        }

        StartCoroutine(UpdateLessOften());
    }

    private IEnumerator UpdateLessOften()
    {
        while (true)
        {
            UpdateSectionPositions();
            yield return waitFor100ms; // Wait for 100ms
        }
    }

    private void UpdateSectionPositions()
    {
        for (int i = 0; i < sections.Length; i++)
        {
            // Check if the section is too far behind the player
            if (sections[i].transform.position.z < playerCarTransform.position.z - sectionLength)
            {
                // Find the farthest section's Z-position
                float farthestZ = GetFarthestSectionZ();

                // Deactivate the current section
                sections[i].SetActive(false);

                // Get a new section from the pool
                GameObject newSection = GetRandomSectionFromPool();

                // Move the new section into place and activate it
                newSection.transform.position = new Vector3(0, 0, farthestZ + sectionLength);
                newSection.SetActive(true);

                // Replace the current section with the new one
                sections[i] = newSection;
            }
        }
    }

    private float GetFarthestSectionZ()
    {
        float farthestZ = float.MinValue;
        foreach (GameObject section in sections)
        {
            if (section.transform.position.z > farthestZ)
            {
                farthestZ = section.transform.position.z;
            }
        }
        return farthestZ;
    }

    private GameObject GetRandomSectionFromPool()
    {
        foreach (GameObject section in sectionsPool)
        {
            if (!section.activeInHierarchy)
            {
                return section;
            }
        }

        Debug.LogWarning("No inactive sections available in the pool! Reusing an active section.");
        return sectionsPool[0]; // Fallback if no inactive sections found
    }
}
