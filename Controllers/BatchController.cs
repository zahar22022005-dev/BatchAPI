using Microsoft.AspNetCore.Mvc;
using BatchAPI.Models;
using BatchAPI.Services;

namespace BatchAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления партиями товаров
    /// </summary>
    [ApiController]                    // Включает автоматическую валидацию моделей
    [Route("api/[controller]")]        // Маршрут: /api/Batch
    public class BatchController : ControllerBase
    {
        private readonly BatchService _batchService;

        /// <summary>
        /// Конструктор контроллера (DI внедряет BatchService)
        /// </summary>
        public BatchController(BatchService batchService)
        {
            _batchService = batchService;
        }

        /// <summary>
        /// GET /api/Batch - получить все партии
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var batches = _batchService.GetAll();
            return Ok(batches);     // 200 OK
        }

        /// <summary>
        /// GET /api/Batch/{id} - получить партию по ID
        /// </summary>
        /// <param name="id">Идентификатор партии</param>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var batch = _batchService.GetById(id);

            if (batch == null)
            {
                return NotFound();    // 404 Not Found
            }

            return Ok(batch);         // 200 OK
        }

        /// <summary>
        /// POST /api/Batch - добавить новую партию
        /// </summary>
        /// <param name="newBatch">Данные партии из тела запроса</param>
        [HttpPost]
        public IActionResult Create([FromBody] Batch newBatch)
        {
            // Проверка валидности данных
            if (string.IsNullOrWhiteSpace(newBatch.ProductName))
            {
                return BadRequest("ProductName is required");  // 400 Bad Request
            }

            if (newBatch.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            if (newBatch.Price <= 0)
            {
                return BadRequest("Price must be greater than 0");
            }

            var createdBatch = _batchService.Add(newBatch);

            // 201 Created + Location заголовок
            return CreatedAtAction(nameof(GetById), new { id = createdBatch.Id }, createdBatch);
        }
    }
}