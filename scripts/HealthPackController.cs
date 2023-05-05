using UnityEngine;

public class HealthPackController : MonoBehaviour
{
    public int healAmount = 20;
    public float rotationSpeed = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuizManager quizManager = FindObjectOfType<QuizManager>();
            quizManager.HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
    private void Update()
{
    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
}
}