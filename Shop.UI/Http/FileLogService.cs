using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwinShop.Shared.Mappers;

namespace Shop.UI.Http
{
    public class FileLogService
    {
        private static readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private static readonly string _filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "failed_logs.txt");

        public static async Task SaveFailedLogAsync(Exception? ex ,string Layer)
        {
            try
            {
                var dir = Path.GetDirectoryName(_filePath);
                if (!Directory.Exists(dir))Directory.CreateDirectory(dir);
                var error = ex.ExceptionToErrorDTO(Layer);

                var json = JsonConvert.SerializeObject(error) + Environment.NewLine;
                await _lock.WaitAsync();
                try
                {
                    await File.AppendAllTextAsync(_filePath, json, Encoding.UTF8);
                }
                finally
                {
                    _lock.Release();
                }
            }
            //fill the catch later
            catch (Exception exception)
            {
            }
        }
    }
}
