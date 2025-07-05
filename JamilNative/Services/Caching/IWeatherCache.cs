namespace JamilNative.Services.Caching;
using WeatherForecast = JamilNative.DataContracts.WeatherForecast;
public interface IWeatherCache
{
    ValueTask<IImmutableList<WeatherForecast>> GetForecast(CancellationToken token);
}
