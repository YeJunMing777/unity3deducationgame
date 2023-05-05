using UnityEngine;

public class HealthPackController1 : MonoBehaviour
{
    public int healAmount = 20;
    public float rotationSpeed = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuizManager1 quizManager1 = FindObjectOfType<QuizManager1>();
            quizManager1.HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
    private void Update()
{
    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
}
}