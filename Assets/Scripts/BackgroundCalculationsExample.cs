using System.Threading;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundCalculationsExample : MonoBehaviour
{
    private CancellationTokenSource cst;
    private SpriteRenderer spriteRenderer;
    public Sprite sprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private async Awaitable Start()
    {
        using (cst = CancellationTokenSource.CreateLinkedTokenSource(
            destroyCancellationToken, Application.exitCancellationToken))
        {
            CancellationToken token = cst.Token;

            double result = await SomeCalculationsAwaitable(token);
            Debug.Log("Результат = " + result);
        }
    }

    private async Awaitable<double> SomeCalculationsAwaitable(CancellationToken token)
    {
        //Переходим в фоновый поток
        await Awaitable.BackgroundThreadAsync();

        //В фоновом потоке нельзя использовать Unity API, привязанный к состоянию главного потока
        //Unity.Random вызовет ошибку
        System.Random rnd = new();
        int length = 100000000;
        double result = 0;

        for (int i = 0; i < length; i++)
        {
            token.ThrowIfCancellationRequested();
            result += Mathf.Sqrt(rnd.Next(100));
        }

        Debug.Log("Закончил вычисления на фоне");

        //Нельзя изменить спрайт в фоновом потоке
        //Поэтому возвращаемся в основной
        await Awaitable.MainThreadAsync();
        spriteRenderer.sprite = sprite;

        return result;
    }
}
