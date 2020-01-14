using JavarottiProgramming.NetCoreFirst.Api.Models;
using JavarottiProgramming.NetCoreFirst.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JavarottiProgramming.NetCoreFirst.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _categoriaRepository.GetAsync()).Select(x => x.ToCategoriaGet());
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        [Produces("application/json", "application/xml")] //FOrmatos válidos para retorno
        public async Task<IActionResult> GetById(int id)
        {
            var data = (await _categoriaRepository.GetAsync(id));

            if (data == null) return NotFound();

            return Ok(data.ToCategoriaGet());
        }

        [HttpPost]
        public IActionResult Add([FromBody] CategoriaPost model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToCategoriaEntity();
            _categoriaRepository.Add(data);

            return CreatedAtRoute("GetCategoryById", new { data.Id }, data.ToCategoriaGet());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]CategoriaPost model)
        {
            var categoria = await _categoriaRepository.GetAsync(id);

            if (categoria == null)
                ModelState.AddModelError("Id", "Categoria não localizada");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            categoria.Update(model.Nome, model.Descricao);
            _categoriaRepository.Update(categoria);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoriaRepository.GetAsync(id);

            if (data == null) return BadRequest(new
            {
                Categoria = new string[] { "Categoria não localizada" }
            });

            _categoriaRepository.Delete(data);

            return Ok();
        }
    }
}