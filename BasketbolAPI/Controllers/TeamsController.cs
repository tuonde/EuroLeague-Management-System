using AutoMapper;
using BasketbolAPI.DTOs;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketbolAPI.Controllers;

/// <summary>
/// EuroLeague takımları için CRUD uç noktaları.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TeamsController : BaseController
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public TeamsController(ITeamRepository teamRepository, IMapper mapper)
    {
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Tüm takımları listeler.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDto>>> GetAll()
    {
        var teams = await _teamRepository.GetAllAsync();
        return Ok(_mapper.Map<List<TeamDto>>(teams));
    }

    /// <summary>
    /// Kimliğe göre tek bir takım döner.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeamDto>> GetById(int id)
    {
        var team = await _teamRepository.GetByIdAsync(id);
        if (team is null)
            return NotFound();

        return Ok(_mapper.Map<TeamDto>(team));
    }

    /// <summary>
    /// Yeni takım oluşturur.
    /// </summary>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<TeamDto>> Create([FromBody] TeamCreateDto teamCreateDto)
    {
        if (await _teamRepository.ExistsByNameAsync(teamCreateDto.Name))
            return BadRequest(new { message = "Bu isimde bir takım zaten mevcut!" });

        var team = _mapper.Map<Team>(teamCreateDto);
        var created = await _teamRepository.AddAsync(team);
        var teamDto = _mapper.Map<TeamDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = teamDto.Id }, teamDto);
    }

    /// <summary>
    /// Mevcut takımı kimliğe göre günceller.
    /// </summary>
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TeamUpdateDto teamUpdateDto)
    {
        var team = _mapper.Map<Team>(teamUpdateDto);
        if (!await _teamRepository.UpdateAsync(id, team))
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Takımı kimliğe göre siler.
    /// </summary>
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _teamRepository.DeleteAsync(id))
            return NotFound();

        return NoContent();
    }
}
