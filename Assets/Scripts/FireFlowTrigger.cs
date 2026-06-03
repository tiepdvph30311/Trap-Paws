using UnityEngine;

public class FireFlowTrigger : MonoBehaviour
{
    [SerializeField] private float fireSpeed = 4f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        float direction = other.transform.localScale.x >= 0f ? 1f : -1f;

        GameObject[] fires = GameObject.FindGameObjectsWithTag("fire");
        foreach (GameObject fire in fires)
        {
            FireFlowController controller = fire.GetComponent<FireFlowController>();
            if (controller == null)
                controller = fire.AddComponent<FireFlowController>();

            controller.StartFlow(direction, fireSpeed);
        }
    }
}
