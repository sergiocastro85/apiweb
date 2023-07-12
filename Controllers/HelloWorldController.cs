using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController: ControllerBase
{

    private readonly ILogger<HelloWorldController> _logger;
    //Inyectamos la dependencia
    IHelloWordService helloWordService;

    TareasContext dbcontext;

    //lo recibimos en el constructor
    public HelloWorldController(IHelloWordService  helloWord,TareasContext db, ILogger<HelloWorldController> logger)
    {
       _logger=logger;
        helloWordService=helloWord;
        dbcontext=db;

    }

    //Finalmente lo usuamos
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Retornando helloworld");
        return Ok(helloWordService.GetHelloworld());
    
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}