using Microsoft.AspNetCore.Mvc;
using BatchAPI.Models;

namespace BatchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchController : ControllerBase
{
    private static readonly List<Batch> _batches = new();
    private static int _nextId = 1;

    [HttpGet]
    public IActionResult GetAll() => Ok(_batches);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var batch = _batches.FirstOrDefault(b => b.Id == id);
        return batch == null ? NotFound() : Ok(batch);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Batch newBatch)
    {
        if (string.IsNullOrWhiteSpace(newBatch.ProductName))
            return BadRequest("ProductName is required");
        
        if (newBatch.Quantity <= 0)
            return BadRequest("Quantity must be greater than 0");
        
        if (newBatch.Price <= 0)
            return BadRequest("Price must be greater than 0");

        newBatch.Id = _nextId++;
        _batches.Add(newBatch);
        return CreatedAtAction(nameof(GetById), new { id = newBatch.Id }, newBatch);
    }
}