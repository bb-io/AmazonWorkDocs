namespace Apps.AmazonWorkDocs.Utils;

public static class AmazonHandler
{
    public static async Task<T> Execute<T>(Func<Task<T>> func)
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            throw new(ex.Message);
        }
    }
}