using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class WallTouchAgent : Agent
{
    public float moveSpeed = 3f;
    public Transform goal;
    private Vector3 startPos;

    public override void Initialize()
    {
        startPos = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = startPos;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(goal.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 move = Vector3.zero;

        switch (actions.DiscreteActions[0])
        {
            case 0: move = Vector3.up; break;
            case 1: move = Vector3.down; break;
            case 2: move = Vector3.left; break;
            case 3: move = Vector3.right; break;
        }

        transform.position += move * moveSpeed * Time.deltaTime;

        AddReward(-0.001f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.W)) discreteActions[0] = 0;
        else if (Input.GetKey(KeyCode.S)) discreteActions[0] = 1;
        else if (Input.GetKey(KeyCode.A)) discreteActions[0] = 2;
        else if (Input.GetKey(KeyCode.D)) discreteActions[0] = 3;
        else discreteActions[0] = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ToxicWall"))
        {
            AddReward(-1.0f);
            EndEpisode();
        }

        if (collision.CompareTag("Door"))
        {
            AddReward(1.0f);
            EndEpisode();
        }
    }
}
