
namespace SimpleAgedCacheCodingExercise
{
    public class Cache : ICache
    {
        public List<CacheEntry> GetDate(string CacheEntryDataSearch, List<CacheEntry> CacheEntries)
        {
            //Check the NULL for Arguments 
            if (string.IsNullOrEmpty(CacheEntryDataSearch) || string.IsNullOrWhiteSpace(CacheEntryDataSearch))
                throw new NullReferenceException();

            //try to find the Search in the List of CacheEntry
            var result = CacheEntries.FindAll(a => a.CacheEntryData == CacheEntryDataSearch)
                        .ToList();

            return result;
        }

        public void PutDate(string CacheEntryData, CacheEntry cacheEntry, List<CacheEntry> cacheEntries)
        {
            //try to find the Search
            var result = GetDate(CacheEntryData, DeleteExpired(cacheEntries)); //try to find any Expired Entry

            //Get the Result and check the the return
            if (result.Count < 1)
            {
                //if no Record Found mean this is new Entry
                cacheEntry.CacheEntryData = $"{CacheEntryData}";
                cacheEntries.Add(cacheEntry);
            }
            else
            {
                //if There is/are Record/s Found means the Entry exist and need to update the entry Edit and Expire Date Time
                foreach (var item in result)
                {
                    item.EditDateTime = DateTime.Now;
                    item.ExpireDateTime = DateTime.Now.AddMinutes(1); //Add one minuts to make it easy
                }
            }
        }

        public List<CacheEntry> DeleteExpired(List<CacheEntry> cacheEntries)
        {
            if (cacheEntries.Count > 1)
            {
                // Create List of CacheEntry to add the record found and delete them
                var result = new List<CacheEntry>();
                foreach (var item in cacheEntries)
                {
                    if (DateTime.Now >= item.ExpireDateTime)
                    {
                        result.Add(item);
                    }
                }

                //if there is/are Record/s Exist then a loop to Delete them from the List
                if (result.Count > 1)
                {
                    foreach (var item in result)
                    {
                        cacheEntries.Remove(item);
                    }
                }
            }
            return cacheEntries;
        }
    }
}
