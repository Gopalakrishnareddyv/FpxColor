using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDistance;
    public float timer;
    public Text timerText;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnEnemy();

        }
    }

    private void SpawnEnemy()
    {
        float randomAngle = Random.Range(0, Mathf.PI * 2.0f);
        GameObject enemyObject = Instantiate(enemyPrefab);
        enemyObject.transform.SetParent(this.transform);
        enemyObject.transform.position = new Vector3(Mathf.Cos(randomAngle) * spawnDistance, 1 + 1, Mathf.Sin(randomAngle) * spawnDistance);

        EnemyController enemyController = enemyObject.GetComponent<EnemyController>();
        enemyController.onEnemyDestroyed = () =>
        {
            OnEnemyDestroyed();
        };
        enemyController.onWrongEnemy = () =>
        {
            onWrongEnemy();
        };
    }

    public void OnEnemyDestroyed()
    {
        Debug.Log("enemy destroyed");
    }
    public void onWrongEnemy()
    {
        Debug.Log("Wrong Enemy");
        Time.timeScale = 0;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time : " + timer;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            timerText.text = "Game Over";
        }
    }
}