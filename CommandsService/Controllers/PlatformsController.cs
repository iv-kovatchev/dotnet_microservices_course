
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase 
{
    private readonly ICommandRepo _repository;
    private readonly IMapper _mapper;

    public PlatformsController(ICommandRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms() {
        Console.WriteLine("--> Getting Platforms from CommandsService");

        var platformItems = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }

    [HttpPost]
    public ActionResult TextInboundConnection() 
    {
        Console.WriteLine("--> Inbound POST # Command Service");

        return Ok("Inbound test of from Platforms Controller");
    }
}