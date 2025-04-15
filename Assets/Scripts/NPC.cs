using UnityEngine;

public class NPC : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float wanderDelay = 2f;
    public Vector2 shopXBounds;
    public Vector2 shopZBounds;
    public LayerMask obstacleLayer;

    private Vector3 targetPosition;
    private bool isWandering = true;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        if (!isWandering) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Invoke(nameof(PickNewTarget), wanderDelay);
            isWandering = false;
        }
    }

    void PickNewTarget()
    {
        Vector3 tryPosition;
        int attempts = 0;

        do
        {
            float x = Random.Range(shopXBounds.x, shopXBounds.y);
            float z = Random.Range(shopZBounds.x, shopZBounds.y);
            tryPosition = new Vector3(x, transform.position.y, z);
            attempts++;
        } while (Physics.CheckSphere(tryPosition, 0.3f, obstacleLayer) && attempts < 10);

        targetPosition = tryPosition;
        isWandering = true;
    }
}
