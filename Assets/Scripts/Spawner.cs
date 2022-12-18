using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawPlace;
    public GameObject[] fruitSpaw;
    public GameObject bomb;
    public float minWait = .3f;
    public float maxWait = 1f;
    public float minForce = 10f;
    public float maxForce = 15f;
    void Start()
    {
        StartCoroutine(SpawFruit());
    }
    private IEnumerator SpawFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait,maxWait));

            Transform t = spawPlace[Random.Range(0, spawPlace.Length)];
            GameObject g=null;
            int ranBomb = Random.Range(0, 100);
            if (ranBomb <= 10)
            {
                g = bomb;
            }
            else
            {
                g = fruitSpaw[Random.Range(0, fruitSpaw.Length)];
            }

            GameObject fruit = Instantiate(g, t.position, t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce),ForceMode2D.Impulse);

            Destroy(fruit, 5f);
        }
    }
}
