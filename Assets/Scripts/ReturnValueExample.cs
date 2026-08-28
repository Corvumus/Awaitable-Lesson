using System.Threading;
using UnityEngine;

public class ReturnValueExample : MonoBehaviour
{
    private async Awaitable Start()
    {
        int result = await GetSomeRandomValuesSumAsync(1000, destroyCancellationToken);

        Debug.Log($"Результат = " + result);
    }

    private async Awaitable<int> GetSomeRandomValuesSumAsync(int values, CancellationToken token)
    {
        int sum = 0;

        for (int i = 0; i < values; i++)
        {
            //token.ThrowIfCancellationRequested();

            sum += Random.Range(1, 100);
            await Awaitable.NextFrameAsync();
        }

        return sum;
    }
}
