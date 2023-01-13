using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;
    public float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Mathf.Abs(player.position.x / 100 * speed * Time.deltaTime);
        if (this.transform.position.x > player.position.x)
        {
            x *= -1;
        }
        this.transform.position = new Vector3(this.transform.position.x + x, this.transform.position.y, this.transform.position.z);
    }

    public void Spawn()
    {
        Debug.Log("Spawn Enemies");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(enemy, new Vector3(0, player.transform.position.y, 0), player.rotation);
        }
    }
}
