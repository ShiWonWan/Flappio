using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text points, record;
    public GameObject pointsGroup, welcomeGroup;

    // Global instance
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update the points on the UI
    // @param int
    // @return void
    public void UpdatePointsUI(int pointsToDisplay)
    {
        points.text = pointsToDisplay.ToString();
    }

    // Update the record on the UI
    // @param int
    // @return void
    public void UpdateRecordUI(int recordToDisplay)
    {
        record.text = "Record: " + recordToDisplay.ToString();
    }

    // Set playing UI or Welcome UI
    // @param none
    // @return void
    public void ChangeUIPlayOrWelcome()
    {
        welcomeGroup.SetActive(!welcomeGroup.activeSelf);
        pointsGroup.SetActive(!pointsGroup.activeSelf);
    }
}
