using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Repository.Layers;

namespace jwtAuthApi.Repository
{
    public class UserMemoryRepository : MemoryRepository<User>
    {
        public UserMemoryRepository()
        {
            LoadSeed();
        }

        private static void LoadSeed()
        {
            MemoryData.Add(
                new User
                {
                    UserName = "admin",
                    Password = "1q2w3e4r",
                    SercretKey = "1qa2ws3ed4rf5tg6yh7uj8il"
                });

            MemoryData.Add(
                new User
                {
                    UserName = "alex",
                    Password = "2w3e4r5t",
                    SercretKey = "2ws3ed4rf5tg6yh7uj8ik9ol"
                });

            MemoryData.Add(
                new User
                {
                    UserName = "steve",
                    Password = "3e4r5t6y",
                    SercretKey = "3ed4rf5tg6yh7uj8ik9ol0pç"
                });

            MemoryData.Add(
                new User
                {
                    UserName = "alice",
                    Password = "4r5t6y7u",
                    SercretKey = "4rf5tg6yh7uj8ik9ol0pç1qa"
                });
        }
    }
}