using AutoMapper;
using BasketbolAPI.DTOs;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketbolAPI.Controllers;

/// <summary>
/// Oyuncular için CRUD ve takıma göre listeleme uç noktaları.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PlayersController : BaseController
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public PlayersController(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Tüm oyuncuları listeler.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
    {
        var players = await _playerRepository.GetAllAsync();
        return Ok(_mapper.Map<List<PlayerDto>>(players));
    }

    /// <summary>
    /// Verilen takım kimliğine bağlı oyuncuları döner.
    /// </summary>
    [HttpGet("team/{teamId:int}")]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetByTeamId(int teamId)
    {
        var players = await _playerRepository.GetPlayersByTeamIdAsync(teamId);
        return Ok(_mapper.Map<List<PlayerDto>>(players));
    }

    /// <summary>
    /// Kimliğe göre tek bir oyuncu döner.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PlayerDto>> GetById(int id)
    {
        var player = await _playerRepository.GetByIdAsync(id);
        if (player is null)
            return NotFound();

        return Ok(_mapper.Map<PlayerDto>(player));
    }

    /// <summary>
    /// Yeni oyuncu oluşturur.
    /// </summary>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<PlayerDto>> Create([FromBody] PlayerCreateDto playerCreateDto)
    {
        var player = _mapper.Map<Player>(playerCreateDto);
        var created = await _playerRepository.AddAsync(player);
        var playerDto = _mapper.Map<PlayerDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = playerDto.Id }, playerDto);
    }

    /// <summary>
    /// Mevcut oyuncuyu kimliğe göre günceller.
    /// </summary>
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PlayerUpdateDto playerUpdateDto)
    {
        var player = _mapper.Map<Player>(playerUpdateDto);
        if (!await _playerRepository.UpdateAsync(id, player))
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Oyuncuyu kimliğe göre siler.
    /// </summary>
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _playerRepository.DeleteAsync(id))
            return NotFound();

        return NoContent();
    }
}
