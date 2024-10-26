using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Sc : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    GameObject enemyPrefab;
    private Player_Sc player;

    [SerializeField]
    GameObject enemyContainer;


    void Start()
        {

            player = GameObject.FindObjectOfType<Player_Sc>();
            StartCoroutine(SpawnRoutine());

        }

        void Update()
        {

        }


        IEnumerator SpawnRoutine()
        {
            while (player.Health>0)
            {
         
                Vector3 position = new Vector3(Random.Range(-player.xVal, player.xVal), player.yVal + 2, 0);
                GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
                new_enemy.transform.parent = enemyContainer.transform;
                yield return new WaitForSeconds(5.0f);



            }
        }   
    
}
