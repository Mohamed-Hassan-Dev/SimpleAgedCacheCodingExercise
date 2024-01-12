namespace SimpleAgedCacheCodingExercise
{
    interface ICache
    {
        void PutDate(string CacheEntryData, CacheEntry cacheEntry, List<CacheEntry> cacheEntries);
        List<CacheEntry> GetDate(string CacheEntryDataSearch, List<CacheEntry> CacheEntries);
    }
}
