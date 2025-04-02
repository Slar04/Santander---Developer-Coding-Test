using Newtonsoft.Json;
using SantanderDeveloperCodingTest.Model.Models;
using SantanderDeveloperCodingTest.Services.Services.Interfaces;

namespace SantanderDeveloperCodingTest.Services.Services
{
    public class StoriesService: IStoriesService
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/")
        };

        public async Task<List<Story?>> GetBestStories(int count)
        {
            // Fetch the list of best story IDs from Hacker News
            var storyIdsResponse = await _httpClient.GetStringAsync("beststories.json");
            var storyIds = JsonConvert.DeserializeObject<List<int>>(storyIdsResponse);

            if (storyIds == null || storyIds.Count == 0)
                return new List<Story?>();

            // Limit the number of stories to fetch based on the request
            var topStoryIds = storyIds.Take(count).ToList();

            // Fetch story details in parallel to improve performance
            var tasks = topStoryIds.Select(GetStoryDetailsAsync);
            var stories = await Task.WhenAll(tasks);

            // Sort stories by score in descending order
            List<Story?> sortedStories = stories.Where(s => s != null).OrderByDescending(s => s.Score).ToList();

            return sortedStories;
        }

        // Fetches details of an individual story asynchronously and counts comments recursively
        private async Task<Story?> GetStoryDetailsAsync(int storyId)
        {
            try
            {
                var storyResponse = await _httpClient.GetStringAsync($"item/{storyId}.json");
                var story = JsonConvert.DeserializeObject<Story>(storyResponse);

                return story;
            }
            catch
            {
                return null;
            }
        }
    }
}
