using UnityEngine;

public class WaitingExample : MonoBehaviour
{
    private async Awaitable Start()
    {
        //Дождаться следующего кадра
        Debug.Log("Жду следующий кадр");
        await Awaitable.NextFrameAsync(destroyCancellationToken);
        Debug.Log("Дождался следующего кадра");

        //Подождать 2 секунды
        Debug.Log("Жду 2 секунды");
        await Awaitable.WaitForSecondsAsync(2, destroyCancellationToken);
        Debug.Log("Подождал 2 секунды");

        //Дождаться конца кадра
        Debug.Log("Жду до конца кадра");
        await Awaitable.EndOfFrameAsync(destroyCancellationToken);
        Debug.Log("Подождал до конца кадра");

        //Дождаться следующего fixed update
        Debug.Log("Жду следующий fixed update");
        await Awaitable.FixedUpdateAsync(destroyCancellationToken);
        Debug.Log("Дождался следующего fixed update");
    }
}



