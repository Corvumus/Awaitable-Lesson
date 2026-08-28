using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SomeRoutine());
    }
    private async Awaitable SomeAwaitableReturningFunction()
    {
        await Awaitable.WaitForSecondsAsync(1);
    }

    private IEnumerator SomeRoutine()
    {
        Debug.Log("Начало корутины");
        yield return SomeAwaitableReturningFunction();
        Debug.Log("Конец корутины");
    }
}
