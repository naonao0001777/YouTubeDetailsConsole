using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeCommentGetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadKey();
        }

        static async Task Test()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCYxw2GRHzN_UUP5kCOSBKuKAIfCdpd3ws"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "もこうの実況";
            searchListRequest.Type = "video";
            searchListRequest.MaxResults = 50;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            foreach (var searchResult in searchListResponse.Items)
            {
                Console.WriteLine($"{searchResult.Id.VideoId}, {searchResult.Snippet.Title}");
            }

        }

    }
}