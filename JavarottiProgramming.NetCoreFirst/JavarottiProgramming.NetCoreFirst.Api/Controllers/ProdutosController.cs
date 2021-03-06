﻿using JavarottiProgramming.NetCoreFirst.Api.Models;
using JavarottiProgramming.NetCoreFirst.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavarottiProgramming.NetCoreFirst.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _produtoRepository.GetAllWithCategoryAsync())
                .Select(x => x.ToProdutoGet());

            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = (await _produtoRepository.GetByIdWithCategoryAsync(id));

            if (data == null) return NotFound();

            return Ok(data.ToProdutoGet());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProdutoPost model)
        {
            var categoria = await _categoriaRepository.GetAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria inválida");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToProdutoEntity();
            _produtoRepository.Add(data);

            var produto = data.ToProdutoGet();
            produto.CategoriaNome = categoria.Nome;

            //return Ok(produto);

            //Retorna objeto batendo na rota GetById
            return CreatedAtRoute("GetProductById", new { data.Id }, produto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProdutoPost model)
        {
            var categoria = await _categoriaRepository.GetAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria inválida");

            var produto = await _produtoRepository.GetAsync(id);

            if (produto == null)
                ModelState.AddModelError("Id", "Produto não localizado");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            produto.Update(model.Nome, model.Preco, model.CategoriaId);
            _produtoRepository.Update(produto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _produtoRepository.GetAsync(id);

            if (data == null) return BadRequest(new
            {
                Produto = new string[] { "Produto não localizado" }
            });

            _produtoRepository.Delete(data);

            return Ok();
        }
    }
}