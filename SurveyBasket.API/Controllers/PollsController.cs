namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public IActionResult GetPolls()
    {
        return Ok(_pollService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var poll = _pollService.Get(id);

        return poll is not null ? Ok(poll) : NotFound();
    }

    [HttpPost("")]
    public IActionResult Add(Poll request)
    {
        var newpoll = _pollService.Add(request);

        return CreatedAtAction(nameof(Get), new { id = newpoll!.Id }, newpoll);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Poll request)
    {
        var isUpdated = _pollService.Update(id, request);

        if (!isUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pollService.Delete(id);

        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}
