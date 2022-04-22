using System.Diagnostics.CodeAnalysis;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using RestSharp;

namespace ClassLibrary1;

[TestFixture]
public class FileUploadTests
{
    [SetUp]
    public void CreateFile()
    {
        // var fileSizeBytes = 490_000_000; ~ approx 500MB
        // var enumerable =
        //     Enumerable.Repeat(Byte.MinValue,
        //         fileSizeBytes); // ~450MB (Drive currently has a limit of 500MB which is being increased)
        // var data = new MemoryStream(enumerable.ToArray());
    }

    [Test]
    [AssertTraffic(AllocatedSizeInBytes = 4900000)]
    [Explicit(
        "This test creates a very large in memory file and is not suitable for running on CI/CD. It is a local test to prove large files can be uploaded. To make it part of CI/CD think of an alternate approach.")]
    public async Task UploadAsStreamAsync_LargeFileSuceeds()
    {
        RestRequest request = new RestRequest(@"api/files"); 
        RestClient client = new RestClient("https://localhost:7156");

        var myStream = File.OpenRead(@"myUpload.txt");

        request.AddFile("gigi.kent", () =>  myStream, "gigi.kent");
        
        var response = await client.ExecuteAsync(request);
            
        Assert.IsTrue(true);
    }

    [Test]
    [AssertTraffic(AllocatedSizeInBytes = 4900000)]
    [Explicit(
        "This test creates a very large in memory file and is not suitable for running on CI/CD. It is a local test to prove large files can be uploaded. To make it part of CI/CD think of an alternate approach.")]
    public void UploadAsStreamAsync_LargeFileSuceedsOldLib()
    {
        // DOESN'T COMPILE WITH restsharp 107, rollback version and uncomment

        // RestRequest request = new RestRequest(@"api/files");
        // request.Method = Method.POST;
        // RestClient client = new RestClient("https://localhost:7156");
        //
        // var myStream = File.OpenRead(@"myUpload.txt");
        //
        // request.Files.Add(
        //     new FileParameter()
        //     {
        //         ContentLength = 490000000,
        //         ContentType = "octet/stream",
        //         FileName = "bla.txt",
        //         Name = "bla",
        //         Writer = s =>
        //         {
        //             myStream.CopyTo(s);
        //             myStream.Dispose();
        //         }
        //     }
        // );
        //
        // var response = client.Execute(request);
        //
        // Assert.IsTrue(true);
    }
}