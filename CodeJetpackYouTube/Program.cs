using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Threading.Tasks;

// Simple console app that reads a video ID and prints the top 10 comments using YouTube Data API v3.
// Requires environment variable YOUTUBE_API_KEY to be set with a valid API key.

async Task<int> Main()
{
    Console.WriteLine("CodeJetpackYouTube - fetch top 10 comments for a YouTube video");

    Console.Write("Enter YouTube video ID (for example: nVpr_BeeFKI): ");
    var videoId = Console.ReadLine()?.Trim();
    if (string.IsNullOrEmpty(videoId))
    {
        Console.Error.WriteLine("No video ID provided. Exiting.");
        return 1;
    }

    var apiKey = Environment.GetEnvironmentVariable("YOUTUBE_API_KEY");
    if (string.IsNullOrEmpty(apiKey))
    {
        Console.Error.WriteLine("Environment variable YOUTUBE_API_KEY is not set. Create an API key in Google Cloud and set this variable.");
        return 2;
    }

    try
    {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = apiKey,
            ApplicationName = "CodeJetpackYouTube"
        });

        var commentRequest = youtubeService.CommentThreads.List("snippet");
        commentRequest.VideoId = videoId;
        commentRequest.MaxResults = 10;
    // The generated request type is CommentThreadsResource.ListRequest
    commentRequest.TextFormat = CommentThreadsResource.ListRequest.TextFormatEnum.PlainText;

        var response = await commentRequest.ExecuteAsync();

        if (response.Items == null || response.Items.Count == 0)
        {
            Console.WriteLine("No comments found for this video or comments are disabled.");
            return 0;
        }

        Console.WriteLine();
        Console.WriteLine($"Top {Math.Min(10, response.Items.Count)} comments for video {videoId}:");
        Console.WriteLine(new string('-', 60));

        int idx = 1;
        foreach (var thread in response.Items)
        {
            var topLevel = thread.Snippet.TopLevelComment;
            var author = topLevel.Snippet.AuthorDisplayName ?? "(unknown)";
            var text = topLevel.Snippet.TextDisplay ?? "";
            var likeCount = topLevel.Snippet.LikeCount ?? 0;
            Console.WriteLine($"{idx}. {author} ({likeCount} likes):");
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 60));
            idx++;
        }

        return 0;
    }
    catch (Google.GoogleApiException gex)
    {
        Console.Error.WriteLine($"YouTube API error: {gex.Message}");
        return 3;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        return 4;
    }
}

return await Main();
