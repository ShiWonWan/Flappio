using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private Vector3 respawnPosition;

    public GameObject pipePrefab;
    public GameObject lastPipeSpawned;
    public Vector3 pipePosition = new Vector3(45, 5, 0);
    public List<KillPlayer> pipes;

    public int points = 0;
    public int record = 0;
    private int contador = 0;

    public float pipesVelocity;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        /// Make invisible the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Set initial respawn position to the spawn (0, 0, 0)
        respawnPosition = PlayerController.instance.transform.position;

        // Set pipes velocity from prefab
        pipesVelocity = pipePrefab.GetComponent<PipeController>().velocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.isOnStart)
            triggerSpaceToStart();
        else
            SpawnNextPipe();
    }

    // Start playing
    private void triggerSpaceToStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.instance.isOnStart = false;
            PlayerController.instance.gravityScale = 5f;
            UIManager.instance.ChangeUIPlayOrWelcome();
            OnPlay();
        }
        else
        {
            PlayerController.instance.gravityScale = 0f;
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        // Inactive the player
        // Death effect
        PlayerController.instance.gameObject.SetActive(false);
        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation);

        // Start coroutine, 2 seconds
        yield return new WaitForSeconds(2f);

        // Destroy pipes
        // Set new record
        // Restart points
        // Restart pipes velocity
        // set isOnStart
        // Change UI
        // Finally, enable the player
        PlayerController.instance.transform.position = respawnPosition;
        DestroyPipes();
        SetRecord();
        points = 0;
        UIManager.instance.UpdatePointsUI(0);
        pipesVelocity = pipePrefab.GetComponent<PipeController>().velocity;
        PlayerController.instance.isOnStart = true;
        UIManager.instance.ChangeUIPlayOrWelcome();
        PlayerController.instance.gameObject.SetActive(true);
    }

    // Destroy all pipes
    public void DestroyPipes()
    {
        foreach(GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            Destroy(pipe);
        }
    }

    // Set spawn point as given vector3
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        // Set respawn posotion as given
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn Point Set");
    }

    // On Play Function
    // @param none
    // @return void
    public void OnPlay()
    {
        lastPipeSpawned = CreateNextPipe();
    }

    // Spawn pipe when last 
    // move 7 in x
    // @param none
    // @return void
    public void SpawnNextPipe()
    {
        if (lastPipeSpawned.GetComponent<PipeController>().transform.position.x <= pipePosition.x - 7)
        {
            lastPipeSpawned = CreateNextPipe();
        }

    }

    // Create next pipe
    // @param none
    // @return GameObject
    public GameObject CreateNextPipe()
    {
        int yPositionBase = Random.Range(2, 9);
        int yPositionDecimal = Random.Range(0, 99);
        float yPosition = yPositionBase + ((float)yPositionDecimal / 100);
        Vector3 newPipePosition = pipePosition;
        newPipePosition.y = (float)yPosition;

        GameObject newPipe = Instantiate(pipePrefab, newPipePosition, Quaternion.identity);
        newPipe.name = "Pipe " + contador;
        ManagePipesVelocity();
        contador++;

        return newPipe;
    }

    /*
        Add points
        @param int
        @return void
     */
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        UIManager.instance.UpdatePointsUI(points);
        SFXManager.instance.playPointSound();
    }

    // Set (or not) the new record, when player ouch
    // @param none
    // @return void
    public void SetRecord()
    {
        if(points > record)
        {
            record = points;
            UIManager.instance.UpdateRecordUI(record);
        }
    }

    // Each 10 points, add 10% of point + 0.5 
    // to the pipes velocity
    public void ManagePipesVelocity()
    {
        if (points % 10 == 0 && points > 0)
        {
            pipesVelocity += (float)points / 10f + 0.5f;
            SFXManager.instance.playSpeedSound();
        }
        EditVelocityAllPipes();
    }

    // Edit velocity all pipes
    // @param none
    // @return void
    public void EditVelocityAllPipes()
    {
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            pipe.GetComponent<PipeController>().velocity = pipesVelocity;
        }
    }

}
