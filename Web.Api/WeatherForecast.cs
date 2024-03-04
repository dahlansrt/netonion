using Application.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Web.Api
{
    public class Storage<T> where T : BaseEntity
    {
        private readonly Dictionary<Guid, T> storage = [];
        public async Task<IEnumerable<T>> GetAsync() => await Task.FromResult(storage.Values);
        public async Task<T> GetAsync(Guid id) => await Task.FromResult(storage[id]);
        public async Task AddAsync(T value) => await Task.FromResult(storage[Guid.NewGuid()] = value);
        public async Task UpdateAsync(Guid id, T value) => await Task.FromResult(storage[id] = value);
        public async Task<bool> RemoveAsync(Guid id) => await Task.FromResult(storage.Remove(id));
    }

    public class WeatherForecast : BaseEntity
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
    public static class WeatherForecastStartupExtension
    {
        public static void AddWeatherForecastPersistence<T>(this IServiceCollection services) where T : BaseEntity
        {
            services.AddSingleton<Storage<T>>();
        }
    }
}
