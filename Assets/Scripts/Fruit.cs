using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruidPrefab;
    public void CreateSliceFruit()
    {
        FindObjectOfType<GameManager>().PlayRandomSound();
        GameObject inst =  Instantiate(slicedFruidPrefab, gameObject.transform.position,transform.rotation);
        Rigidbody[] rbSlice = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rbSlice)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(250,500),transform.position,5f);
        }
        Destroy(gameObject);
        Destroy(inst, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        CreateSliceFruit();
        FindObjectOfType<GameManager>().IncreaseScore();
    }
}
