#region Usings

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Scripts;

#endregion

namespace EvenSo.Logic.Containers
{
    public sealed partial class EventContainer : Container
    {
        #region Class delegation 

        public override string Id => _container.Id;

        public override Database Database => _container.Database;

        public override Conflicts Conflicts => _container.Conflicts;

        public override Scripts Scripts => _container.Scripts;

        public override async Task<ItemResponse<T>> CreateItemAsync<T>(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.CreateItemAsync(item, partitionKey, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> CreateItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.CreateItemStreamAsync(streamPayload, partitionKey, requestOptions, cancellationToken);

        public override TransactionalBatch CreateTransactionalBatch(PartitionKey partitionKey) =>
            _container.CreateTransactionalBatch(partitionKey);

        public override async Task<ContainerResponse> DeleteContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.DeleteContainerAsync(requestOptions, cancellationToken);

        public override async Task<ResponseMessage> DeleteContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.DeleteContainerStreamAsync(requestOptions, cancellationToken);

        public override async Task<ItemResponse<T>> DeleteItemAsync<T>(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.DeleteItemAsync<T>(id, partitionKey, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> DeleteItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.DeleteItemStreamAsync(id, partitionKey, requestOptions, cancellationToken);

        public override ChangeFeedEstimator GetChangeFeedEstimator(string processorName, Container leaseContainer) =>
            _container.GetChangeFeedEstimator(processorName, leaseContainer);

        public override ChangeFeedProcessorBuilder GetChangeFeedEstimatorBuilder(string processorName, ChangesEstimationHandler estimationDelegate, TimeSpan? estimationPeriod = null) =>
            _container.GetChangeFeedEstimatorBuilder(processorName, estimationDelegate, estimationPeriod);

        public override FeedIterator<T> GetChangeFeedIterator<T>(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null) =>
            _container.GetChangeFeedIterator<T>(changeFeedStartFrom, changeFeedMode, changeFeedRequestOptions);

        public override ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder<T>(string processorName, ChangesHandler<T> onChangesDelegate) =>
            _container.GetChangeFeedProcessorBuilder(processorName, onChangesDelegate);

        public override ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder<T>(string processorName, ChangeFeedHandler<T> onChangesDelegate) =>
            _container.GetChangeFeedProcessorBuilder(processorName, onChangesDelegate);

        public override ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder(string processorName, ChangeFeedStreamHandler onChangesDelegate) =>
            _container.GetChangeFeedProcessorBuilder(processorName, onChangesDelegate);

        public override ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilderWithManualCheckpoint<T>(string processorName, ChangeFeedHandlerWithManualCheckpoint<T> onChangesDelegate) =>
            _container.GetChangeFeedProcessorBuilderWithManualCheckpoint(processorName, onChangesDelegate);

        public override ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilderWithManualCheckpoint(string processorName, ChangeFeedStreamHandlerWithManualCheckpoint onChangesDelegate) =>
            _container.GetChangeFeedProcessorBuilderWithManualCheckpoint(processorName, onChangesDelegate);

        public override FeedIterator GetChangeFeedStreamIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null) =>
            _container.GetChangeFeedStreamIterator(changeFeedStartFrom, changeFeedMode, changeFeedRequestOptions);

        public override async Task<IReadOnlyList<FeedRange>> GetFeedRangesAsync(CancellationToken cancellationToken = default) =>
            await _container.GetFeedRangesAsync(cancellationToken);

        public override IOrderedQueryable<T> GetItemLinqQueryable<T>(bool allowSynchronousQueryExecution = false, string? continuationToken = null, QueryRequestOptions? requestOptions = null, CosmosLinqSerializerOptions? linqSerializerOptions = null) =>
            _container.GetItemLinqQueryable<T>(allowSynchronousQueryExecution, continuationToken, requestOptions, linqSerializerOptions);

        public override FeedIterator<T> GetItemQueryIterator<T>(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) =>
            _container.GetItemQueryIterator<T>(queryDefinition, continuationToken, requestOptions);

        public override FeedIterator<T> GetItemQueryIterator<T>(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null) =>
            _container.GetItemQueryIterator<T>(queryText, continuationToken, requestOptions);

        public override FeedIterator<T> GetItemQueryIterator<T>(FeedRange feedRange, QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) =>
            GetItemQueryIterator<T>(feedRange, queryDefinition, continuationToken, requestOptions);

        public override FeedIterator GetItemQueryStreamIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) =>
            GetItemQueryStreamIterator(queryDefinition, continuationToken, requestOptions);

        public override FeedIterator GetItemQueryStreamIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null) =>
            _container.GetItemQueryStreamIterator(queryText, continuationToken, requestOptions);

        public override FeedIterator GetItemQueryStreamIterator(FeedRange feedRange, QueryDefinition queryDefinition, string continuationToken, QueryRequestOptions? requestOptions = null) =>
            _container.GetItemQueryStreamIterator(queryDefinition, continuationToken);

        public override async Task<ItemResponse<T>> PatchItemAsync<T>(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.PatchItemAsync<T>(id, partitionKey, patchOperations, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> PatchItemStreamAsync(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.PatchItemStreamAsync(id, partitionKey, patchOperations, requestOptions, cancellationToken);

        public override async Task<ContainerResponse> ReadContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReadContainerAsync(requestOptions, cancellationToken);

        public override async Task<ResponseMessage> ReadContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReadContainerStreamAsync(requestOptions, cancellationToken);

        public override async Task<ItemResponse<T>> ReadItemAsync<T>(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReadItemAsync<T>(id, partitionKey, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> ReadItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReadItemStreamAsync(id, partitionKey, requestOptions, cancellationToken);
        
        public override async Task<FeedResponse<T>> ReadManyItemsAsync<T>(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReadManyItemsAsync<T>(items, readManyRequestOptions, cancellationToken);

        public override async Task<ResponseMessage> ReadManyItemsStreamAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReadManyItemsStreamAsync(items, readManyRequestOptions, cancellationToken);

        public override async Task<int?> ReadThroughputAsync(CancellationToken cancellationToken = default) =>
            await _container.ReadThroughputAsync(cancellationToken);

        public override async Task<ThroughputResponse> ReadThroughputAsync(RequestOptions requestOptions, CancellationToken cancellationToken = default) =>
            await _container.ReadThroughputAsync(requestOptions, cancellationToken);

        public override async Task<ContainerResponse> ReplaceContainerAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReplaceContainerAsync(containerProperties, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> ReplaceContainerStreamAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReplaceContainerStreamAsync(containerProperties, requestOptions, cancellationToken);

        public override async Task<ItemResponse<T>> ReplaceItemAsync<T>(T item, string id, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
             await _container.ReplaceItemAsync(item, id, partitionKey, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> ReplaceItemStreamAsync(Stream streamPayload, string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReplaceItemStreamAsync(streamPayload, id, partitionKey, requestOptions, cancellationToken);

        public override async Task<ThroughputResponse> ReplaceThroughputAsync(int throughput, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReplaceThroughputAsync(throughput, requestOptions, cancellationToken);

        public override async Task<ThroughputResponse> ReplaceThroughputAsync(ThroughputProperties throughputProperties, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.ReplaceThroughputAsync(throughputProperties, requestOptions, cancellationToken);

        public override async Task<ItemResponse<T>> UpsertItemAsync<T>(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.UpsertItemAsync(item, partitionKey, requestOptions, cancellationToken);

        public override async Task<ResponseMessage> UpsertItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) =>
            await _container.UpsertItemStreamAsync(streamPayload, partitionKey, requestOptions, cancellationToken);

        #endregion
    }
}
