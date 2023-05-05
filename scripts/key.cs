using UnityEngine;

public class key : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuizManager quizManager = FindObjectOfType<QuizManager>();
            quizManager.StartCoroutine(quizManager.Showkey());
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
