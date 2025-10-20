# CodeJetpackYouTube

Small console app that fetches the top 10 comments for a YouTube video using the YouTube Data API v3.

Prerequisites:
- .NET 9.0 SDK
- A Google Cloud API key with YouTube Data API enabled

Setup:
1. Set the environment variable `YOUTUBE_API_KEY` to your API key.

   On Windows PowerShell (temporary for session):

   ```powershell
   $env:YOUTUBE_API_KEY = 'YOUR_API_KEY'
   ```

Run:

1. From the workspace root:

```powershell
dotnet run --project .\CodeJetpackYouTube\
```

The app will prompt for a video ID (for example: `nVpr_BeeFKI`) and print the top 10 comments.
