using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text visitedCubesText;
    public Patrol patrol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol == null||visitedCubesText == null)
        {
            return;
        }

        visitedCubesText.text = "Visited Cubes: " + patrol.GetVisitedCubesCount();

    }
}
