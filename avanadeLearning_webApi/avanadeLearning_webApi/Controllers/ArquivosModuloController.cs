using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivosModuloController : ControllerBase
    {
        private IBaseRepository<ArquivoModulo> _ArquivoRepository { get; set; }

        public ArquivosModuloController()
        {
            _ArquivoRepository = new ArquivoModuloRepository();
        }

        // Role = 1 para Admin  
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ArquivoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ArquivoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] ArquivoModulo novoArquivo)
        {
            try
            {
                if (Request.Form.Files["Arquivo"] != null)
                {
                    var file = Request.Form.Files["Arquivo"];
                    var folderName = Path.Combine("Resources", "Files");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        string extensao = fileName + "-extensao/Ok";

                        if (extensao.Contains(".rar-extensao/Ok") || extensao.Contains(".zip-extensao/Ok"))
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            novoArquivo.Arquivo = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira um arquivo em .rar ou .zip");
                        }
                    }
                }
                else
                {
                    return BadRequest("Insira um arquivo");
                }
                _ArquivoRepository.Cadastrar(novoArquivo);

                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPut("{id}"), DisableRequestSizeLimit]
        public IActionResult Put([FromForm] int id, ArquivoModulo arquivoAtualizado)
        {
            try
            {
                ArquivoModulo arquivoModuloBuscado = _ArquivoRepository.BuscarPorId(id);

                if (Request.Form.Files["Arquivo"] != null)
                {
                    var file = Request.Form.Files["Arquivo"];
                    var folderName = Path.Combine("Resources", "Files");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        if (fileName != arquivoModuloBuscado.Arquivo)
                        {
                            string extensao = fileName + "-extensao/Ok";

                            if (extensao.Contains(".rar-extensao/Ok") || extensao.Contains(".zip-extensao/Ok"))
                            {
                                var fullPathAnterior = Path.Combine(pathToSave, arquivoModuloBuscado.Arquivo);
                                System.IO.File.Delete(fullPathAnterior.ToString());
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }

                                arquivoAtualizado.Arquivo = fileName.ToString();
                            }
                            else
                            {
                                return BadRequest("Insira um arquivo em .rar ou .zip");
                            }
                        }
                    }
                }
                _ArquivoRepository.Atualizar(id, arquivoAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        // Role = 2 para Prof 
        [Authorize(Roles = "1,2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ArquivoModulo arquivoModuloBuscado = _ArquivoRepository.BuscarPorId(id);

                var folderName = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fullPathAnterior = Path.Combine(pathToSave, arquivoModuloBuscado.Arquivo);
                System.IO.File.Delete(fullPathAnterior.ToString());

                _ArquivoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
