#region Usings

using EvenSo.Events;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Linq;

#endregion

namespace EvenSo.Triggers
{
    public static class TriggerLogic
    {
        public static async Task RunAsync(EventContainer container)
        {

            var input = container.GetItemLinqQueryable<JObject>(true).ToList();

            //var updates = new List<Update>();
            //foreach (var item in input)
            //{
            //    if (item[])
            //}

            Console.WriteLine(input[0]["Type"]);

            var path = "/m/0/q/b/0/h/m/0/j/name";
            var op = PatchOperation.Add(path, "Barni");

            var ops = new[] { op };

            if(false)
            {
                await PatchAsync(async (IReadOnlyList<PatchOperation> operations) => 
                    await container.PatchItemAsync<object>("f7051ff5-b1df-4c3c-ab14-5d087dc4e1e6", new PartitionKey("uj"), operations), ops);

            } 
            else
            {
                var item = (await container.ReadItemAsync<JObject>("f7051ff5-b1df-4c3c-ab14-5d087dc4e1e6", new PartitionKey("uj"))).Resource;

                

                await container.UpsertItemAsync<JObject>(item);

                _ = 0;
            }

            _ = 0;
        }

        private static async Task PatchAsync(Func<IReadOnlyList<PatchOperation>, Task<ItemResponse<object>>> patchItemAsync, IReadOnlyList<PatchOperation> operations)
        {
            try { await patchItemAsync(operations); }

            catch (CosmosException cosmosException)
            {
                if(cosmosException.Is(CosmosExceptionType.InvalidPath))
                {
                    var invalidOperation = operations[int.Parse(cosmosException.Message.Split("Operation(")[1].Split(")")[0]) - 1];

                    await HandleInvalidPathAsync(patchItemAsync, invalidOperation, cosmosException);

                    if (operations.Where(o => o != invalidOperation) is { } validOperations && validOperations.Any())
                    {
                        await PatchAsync(patchItemAsync, operations);
                    }
                }
            }
        }

        private static async Task HandleInvalidPathAsync(Func<PatchOperation[], Task<ItemResponse<object>>> patchItemAsync, PatchOperation op, CosmosException exception, int validIndex = -1)
        {
            var pathParts = op.Path.Split("/")[1..^1];

            validIndex = (validIndex < 0 ? pathParts.Length : validIndex) - 1;

            while (pathParts[validIndex] != exception.Message.Split("'")[1]) { validIndex--; }

            var invalidPath = pathParts[validIndex..];

            JObject segment = new();
            for (int i = invalidPath.Length - 1; i >= 0; i--)
            {
                segment = int.TryParse(invalidPath[i], out _) ? 
                    new() { [invalidPath[--i]] = new JArray { segment } } : 
                    new() { [invalidPath[i]] = segment };
            }

            try { await patchItemAsync(new[] { PatchOperation.Add("/" + pathParts[0], segment.First.First), op }); }

            catch (CosmosException cosmosException)
            {
                if(cosmosException.Is(CosmosExceptionType.InvalidPath))
                {
                    await HandleInvalidPathAsync(patchItemAsync, op, exception, validIndex);
                }
            }
        }
    }
}
