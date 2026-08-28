using UnityEngine;

public class UnsafeExample : MonoBehaviour
{
    async Awaitable Start()
    {
        var awaitable = SomeAwaitableReturningFunction();
        Debug.Log("Начало первого ожидания");
        await awaitable;
        Debug.Log("Конец первого ожидания");

        Debug.Log("Начало второго ожидания");
        // taskWithResult уже вернулся в пул. Повторное ожидание не выполнится.
        await awaitable;
        Debug.Log("Конец второго ожидания");
    }

    private async Awaitable SomeAwaitableReturningFunction()
    {
        await Awaitable.WaitForSecondsAsync(1);
    }
}