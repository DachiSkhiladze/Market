using FlatRockTechnology.OnlineMarket.Models.Redis;

namespace AuthenticationLayer.Token.Redis
{
    public interface IRedisDB
    {
        Task DeleteAsync(string refreshToken);
        Task<RedisTokenValueModel?> GetAsync(string refreshToken);
        Task InsertAsync(string refreshToken, RedisTokenValueModel value);
    }
}