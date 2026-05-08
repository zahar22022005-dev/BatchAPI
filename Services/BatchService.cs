using BatchAPI.Models;

namespace BatchAPI.Services
{
    /// <summary>
    /// Сервис для управления партиями товаров
    /// </summary>
    public class BatchService
    {
        // Статический список для хранения партий (работает как "база данных" в памяти)
        private static List<Batch> _batches = new List<Batch>();

        // Счётчик для генерации ID (автоинкремент)
        private static int _nextId = 1;

        /// <summary>
        /// Получить все партии
        /// </summary>
        public IEnumerable<Batch> GetAll()
        {
            return _batches;
        }

        /// <summary>
        /// Получить партию по ID
        /// </summary>
        /// <param name="id">Идентификатор партии</param>
        /// <returns>Партия или null, если не найдена</returns>
        public Batch GetById(int id)
        {
            return _batches.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Добавить новую партию
        /// </summary>
        /// <param name="batch">Данные партии</param>
        /// <returns>Добавленная партия с присвоенным ID</returns>
        public Batch Add(Batch batch)
        {
            batch.Id = _nextId++;
            _batches.Add(batch);
            return batch;
        }
    }
}