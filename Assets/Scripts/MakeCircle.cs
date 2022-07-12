using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MakeCircle : MonoBehaviour
{
    public GameObject part;
    public int countOfCircles = 0;
    public Material unsafeMaterial;
    public Material finishMaterial;
    GameObject[] parts = new GameObject[12];
    System.Random random = new System.Random();
    public static int countOfSetActive = 0;
    public GameObject cylinder;

    void Start()
    {
        countOfCircles = GameManager.currentLevelIndex + 10;

        GameObject tower = Instantiate(cylinder, new Vector3(0, -2.5f * countOfCircles+2.5f, 0), Quaternion.Euler(0, 0, 0)); // position
        tower.transform.localScale = new Vector3(5, 10f*countOfCircles, 5); // size

        for (int j = 0; j < countOfCircles; j++) // создание кругов
        {
            int[] numbers = Enumerable.Range(0, 12).OrderBy(n => random.Next()).ToArray();

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = Instantiate(part, new Vector3(0, -10 * j, 0), Quaternion.Euler(-90, 30 * i, 0));
                parts[i].transform.parent = transform;
            }

            int countOfUnsafe = random.Next(1, 3);
            int countOfHoles = 2;
            countOfSetActive += countOfHoles;

            if (j == 0) // 1-й круг
            {
                for (int i = 0; i < countOfHoles; i++)
                {
                    parts[numbers[i]].SetActive(false);
                }
            }
            else if (j != countOfCircles-1) // все круги, кроме первого и последнего
            {
                for (int i = 0; i < countOfHoles; i++)
                {
                    parts[numbers[i]].SetActive(false);
                }

                for (int i = 0; i < countOfUnsafe; i++)
                {
                    parts[random.Next(0, 12)].GetComponent<MeshRenderer>().material = unsafeMaterial;
                }
            }
            else
            {
                for (int i = 0; i < parts.Length; i++) // последний круг
                {
                    parts[i].GetComponent<MeshRenderer>().material = finishMaterial;
                }
            }
        }


    }
}
