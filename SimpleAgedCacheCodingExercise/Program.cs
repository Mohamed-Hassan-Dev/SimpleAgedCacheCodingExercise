// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleAgedCacheCodingExercise;

//Register the Service
IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    service => service.AddScoped<ICache, Cache>()
    ).Build();

//Using the Service
var app = _host.Services.GetRequiredService<ICache>();

//Create 3 instance of CacheEntry
var newRecord01 = new CacheEntry();
var newRecord02 = new CacheEntry();
var newRecord03 = new CacheEntry();

//Create List of CacheEntry
var newRecordList = new List<CacheEntry>();

//Add Data to CacheEntry
app.PutDate("Hello There01", newRecord01, newRecordList);// Record contain "Hello There01"
app.PutDate("Hello There02", newRecord02, newRecordList);// Record contain "Hello There02"
app.PutDate("Hello There01", newRecord03, newRecordList);// Record contain "Hello There01" as Duplicate Entry and should not add as it's already Exist

//Print CacheEntries 
PrintEntries();

//Sleep for 70 Seconds
Thread.Sleep(70000);

//Create instance of CacheEntry
var newRecord04 = new CacheEntry();
//Add Data to CacheEntry
app.PutDate("Hello There04", newRecord04, newRecordList); // Record will be added after Delete the Expired Records 

//Print CacheEntries 
PrintEntries();

void PrintEntries()
{
    Console.WriteLine("-------------------------------------------------------");
    if (newRecordList.Count < 1 || newRecordList is null || newRecordList == null)
        Console.WriteLine("No Record...");

    foreach (var entry in newRecordList)
        Console.WriteLine(entry);
}
Console.ReadLine();

