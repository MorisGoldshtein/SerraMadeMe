#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly APIProjectDBContext _context;

        public CharactersController(APIProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<Response>> GetCharacters()
        {
            var response = new Response();
            try
            {
                var output = await _context.Characters.ToListAsync();
                response.CharactersList.AddRange(output);
                response.statusCode = 200;
                response.statusDescription = "OK";
            }
            catch (DbUpdateException)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request";
            }

            return response;
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetCharacter(int id)
        {
            var response = new Response();
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }

            response.CharactersList.Add(character);
            response.statusCode = 200;
            response.statusDescription = "OK";

            return response;
        }

        // PUT: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<Response>> PutCharacter(Character character)
        {
            var response = new Response();

            character.CreationDate = DateTime.Now;

            _context.Characters.Add(character);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterExists(character.CharacterId))
                {
                    response.statusCode = 409;
                    response.statusDescription = "Conflict";
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.statusCode = 201;
            response.statusDescription = "Created";
            return response;

            //return CreatedAtAction("GetCharacter", new { id = character.CharacterId }, character);
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCharacter(int id, Character character)
        {
            var response = new Response();

            if (id != character.CharacterId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request";
                return response;
            }

            character.CreationDate = DateTime.Now;
            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Not Found";
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.statusCode = 204;
            response.statusDescription = "No Content";
            return response;
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostCharacter(Character character)
        {
            var response = new Response();

            character.CreationDate = DateTime.Now;
            _context.Characters.Add(character);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterExists(character.CharacterId))
                {
                    response.statusCode = 409;
                    response.statusDescription = "Conflict";
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.statusCode = 201;
            response.statusDescription = "Created";
            return response;

            //return CreatedAtAction("GetCharacter", new { id = character.CharacterId }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteCharacter(int id)
        {
            var response = new Response();

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            response.statusCode = 204;
            response.statusDescription = "No Content";
            return response;
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
