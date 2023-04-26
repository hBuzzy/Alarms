using UnityEngine;
using UnityEngine.Events;

public class IntrusionDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTheifEnter = new UnityEvent();
    [SerializeField] private UnityEvent _onTheifExit = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _onTheifEnter.Invoke();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            _onTheifExit.Invoke();
        }
    }
}
