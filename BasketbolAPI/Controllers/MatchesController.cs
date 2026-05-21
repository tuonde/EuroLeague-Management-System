using AutoMapper;
using BasketbolAPI.DTOs;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketbolAPI.Controllers;

/// <summary>
/// Maçlar için CRUD ve takıma göre listeleme uç noktaları.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MatchesController : BaseController
{
    private readonly IMatchRepository _matchRepository;
    private readonly IMapper _mapper;

    public MatchesController(IMatchRepository matchRepository, IMapper mapper)
    {
        _matchRepository = matchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Tüm maçları listeler.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchDto>>> GetAll()
    {
        var matches = await _matchRepository.GetAllAsync();
        return Ok(_mapper.Map<List<MatchDto>>(matches));
    }

    /// <summary>
    /// Ev veya deplasman olarak verilen takımın yer aldığı maçları döner.
    /// </summary>
    [HttpGet("team/{teamId:int}")]
    public async Task<ActionResult<IEnumerable<MatchDto>>> GetByTeamId(int teamId)
    {
        var matches = await _matchRepository.GetMatchesByTeamIdAsync(teamId);
        return Ok(_mapper.Map<List<MatchDto>>(matches));
    }

    /// <summary>
    /// Kimliğe göre tek bir maç döner.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MatchDto>> GetById(int id)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        if (match is null)
            return NotFound();

        return Ok(_mapper.Map<MatchDto>(match));
    }

    /// <summary>
    /// Yeni maç oluşturur.
    /// </summary>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<MatchDto>> Create([FromBody] MatchCreateDto matchCreateDto)
    {
        var match = _mapper.Map<Match>(matchCreateDto);
        var created = await _matchRepository.AddAsync(match);
        var matchDto = _mapper.Map<MatchDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = matchDto.Id }, matchDto);
    }

    /// <summary>
    /// Mevcut maçı kimliğe göre günceller.
    /// </summary>
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] MatchUpdateDto matchUpdateDto)
    {
        var match = _mapper.Map<Match>(matchUpdateDto);
        if (!await _matchRepository.UpdateAsync(id, match))
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Maçı kimliğe göre siler.
    /// </summary>
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _matchRepository.DeleteAsync(id))
            return NotFound();

        return NoContent();
    }
}
