using UnityEngine;

public class NpcTriggerInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<IExecuteActionOnTrigger>().OnTriggerExecution();
        }
    }
}