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
    public class WeaponsController : ControllerBase
    {
        private readonly APIProjectDBContext _context;

        public WeaponsController(APIProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Weapons
        [HttpGet]
        public async Task<ActionResult<Response>> GetWeapons()
        {
            var response = new Response();
            try
            {
                var output = await _context.Weapons.ToListAsync();
                response.WeaponsList.AddRange(output);
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

        // GET: api/Weapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetWeapon(int id)
        {
            var response = new Response();
            var weapon = await _context.Weapons.FindAsync(id);

            if (weapon == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }

            response.WeaponsList.Add(weapon);
            response.statusCode = 200;
            response.statusDescription = "OK";

            return response;
        }

        // PUT: api/Weapons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<Response>> PutWeapon(Weapon weapon)
        {
            var response = new Response();

            _context.Weapons.Add(weapon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeaponExists(weapon.WeaponId))
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

            //return CreatedAtAction("GetWeapon", new { id = weapon.WeaponId }, weapon);
        }

        // PUT: api/Weapons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutWeapon(int id, Weapon weapon)
        {
            var response = new Response();

            if (id != weapon.WeaponId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request";
                return response;
            }

            _context.Entry(weapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(id))
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

        // POST: api/Weapons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostWeapon(Weapon weapon)
        {
            var response = new Response();

            _context.Weapons.Add(weapon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeaponExists(weapon.WeaponId))
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

            //return CreatedAtAction("GetWeapon", new { id = weapon.WeaponId }, weapon);
        }

        // DELETE: api/Weapons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteWeapon(int id)
        {
            var response = new Response();

            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }

            _context.Weapons.Remove(weapon);
            await _context.SaveChangesAsync();

            response.statusCode = 204;
            response.statusDescription = "No Content";
            return response;
        }

        private bool WeaponExists(int id)
        {
            return _context.Weapons.Any(e => e.WeaponId == id);
        }
    }
}
