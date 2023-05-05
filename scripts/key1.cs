using UnityEngine;

public class key1 : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuizManager1 quizManager = FindObjectOfType<QuizManager1>();
            quizManager.StartCoroutine(quizManager.Showkey());
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
