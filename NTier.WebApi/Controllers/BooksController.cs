using Microsoft.AspNetCore.Mvc;
using NTier.Entities.Models;
using NTier.Repositories.Contracts;

namespace NTier.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IRepositoryManager _manager;

    public BooksController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
    {
        try
        {
            var book = _manager.Book.GetOneBookById(id, false);
            if (book == null)
                return NotFound($"Book with id {id} not found.");

            return Ok(book);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        try
        {
            if (book == null)
                return BadRequest("Book object is null.");

            _manager.Book.CreateOneBook(book);
            _manager.Save();

            return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOneBook([FromRoute] int id, [FromBody] Book book)
    {
        try
        {
            if (book == null)
                return BadRequest("Book object is null.");

            var entity = _manager.Book.GetOneBookById(id, true);
            if (entity == null)
                return NotFound($"Book with id {id} not found.");

            if (id != book.Id)
                return BadRequest("ID mismatch.");

            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Save();
            return Ok(book);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
    {
        try
        {
            var entity = _manager.Book.GetOneBookById(id, false);
            if (entity == null)
                return NotFound($"Book with id {id} not found.");

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
