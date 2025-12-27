using UnityEngine;

public class PlayerExploration : MonoBehaviour
{
    [SerializeField] private float walkTime;
    [SerializeField] private float currentWalkTime;
    [SerializeField] private bool canWalk;
    [SerializeField] private Vector2 lastPosition;

    void Start()
    {
        canWalk = true;
        currentWalkTime = walkTime;
    }

    void Update()
    {
        UpdateWalkTime();
        Controls();
    }

    private void Controls()
    {
        if (Input.GetKey(KeyCode.W)) Walk(Vector2.up);
        else if (Input.GetKey(KeyCode.S)) Walk(Vector2.down);
        else if (Input.GetKey(KeyCode.A)) Walk(Vector2.left);
        else if (Input.GetKey(KeyCode.D)) Walk(Vector2.right);
    }

    public void Walk(Vector2 dir)
    {
        if (!canWalk) return;

        canWalk = false;
        currentWalkTime = 0.0f;
        lastPosition = transform.position;
        transform.position += (Vector3)dir;
    }

    private void UpdateWalkTime()
    {
        currentWalkTime += Time.deltaTime;
        if (currentWalkTime >= walkTime)
        {
            canWalk = true;
        }
        else
        {
            canWalk = false;
        }
    }
}
