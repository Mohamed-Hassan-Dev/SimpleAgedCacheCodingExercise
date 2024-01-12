namespace SimpleAgedCacheCodingExercise
{
    public class CacheEntry
    {
        public Guid CacheEntryID { get; set; } = Guid.NewGuid();
        public string? CacheEntryData { get; set; }
        public DateTime CreateDateTime { get; init; } = DateTime.Now;
        public DateTime EditDateTime { get; set; } = DateTime.Now;
        public DateTime ExpireDateTime { get; set; } = DateTime.Now.AddMinutes(1);

        public override string? ToString()
        {
            return $"Data ID: {CacheEntryID}, Data Entry: {CacheEntryData}, Created: {CreateDateTime}, Edit: {EditDateTime}, Expired {ExpireDateTime}";
        }
    }


}
