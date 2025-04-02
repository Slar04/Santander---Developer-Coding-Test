using SantanderDeveloperCodingTest.Model.Models;
namespace SantanderDeveloperCodingTest.Services.Services.Interfaces
{
    public interface IStoriesService
    {
        public Task<List<Story?>> GetBestStories(int count);
    }
}
