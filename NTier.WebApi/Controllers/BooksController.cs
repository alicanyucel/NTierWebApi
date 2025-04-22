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
    [HttpGet("{id:int")]
    public IActionResult GetOneBook([FromRoute(Name ="id")] int id)
    {
        try
        {
            var book = _manager.Book.GetOneBookById(id, false);
            return Ok(book);
        }
        catch (Exception ex)
        {
           throw new Exception(ex.Message);
        }
    }
    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        try
        {
            if (book is null)
                return BadRequest();
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book) 
    {
        try
        {
            var entity = _manager.Book.GetOneBookById(id, true);
            if (entity is null)
            {
                return NotFound();
            }
            if(id!=book.Id)
            {
                return BadRequest();
            }
            entity.Title = book.Title;
            entity.Price = book.Price;
            _manager.Save();
            return Ok(book);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneBook([FromRoute(Name ="id")] int id)
    {
        try
        {
            var entity=_manager.Book.GetOneBookById(id,true);
            return Ok(entity);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
