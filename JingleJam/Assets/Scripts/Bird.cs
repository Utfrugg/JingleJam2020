using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    Vector3 startPos;
    Vector3 goalPos;
    public List<Vector3> goalPositions;
    public float hopTime = 0.5f;
    float elapsedhopTime = 0;
    public float hopHeight = 2;
    public float hopXRange = 1;
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        startPos = trans.position;
        goalPos = startPos;
        for (int i = 0; i < 3; i++)
        {
            float hopX = Random.Range(-hopXRange, hopXRange);
            Vector3 newGoalPos = startPos;
            newGoalPos.x += hopX;
            goalPositions.Add(newGoalPos);
        }
        goalPos = goalPositions[0];
        goalPositions.Add(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedhopTime += Time.deltaTime;
        float heightModifier = Mathf.Sin(elapsedhopTime / hopTime * Mathf.PI);
        float HopThing = elapsedhopTime / hopTime;
        trans.position = new Vector3(Mathf.Lerp(startPos.x, goalPos.x, HopThing), startPos.y + heightModifier * hopHeight, startPos.z);
        //trans.position = new Vector3(, trans.position.y, trans.position.z);

        if (elapsedhopTime > hopTime)
        {
            elapsedhopTime = 0;
            startPos = goalPos;
            goalPos = goalPositions[Random.Range(0, goalPositions.Count-1)];
            
        }
    }

}
