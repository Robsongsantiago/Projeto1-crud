using Microsoft.AspNetCore.Mvc;
using Projeto1.Context;
using Projeto1.DTO;
using Projeto1.Models;

namespace Projeto1.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly ApplicationContext appContext;

        public AlunoController(ApplicationContext context)
        {
            this.appContext = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var alunos = this.appContext.alunos.ToList();
            return Ok(alunos);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var aluno = this.appContext.alunos.Where(x => x.Id == id).FirstOrDefault();
            return Ok(aluno);
        }
        [HttpPost]
        public ActionResult Post(AlunoDTO alunoDTO)
        {
            var aluno = new Aluno();
            aluno.Nome = alunoDTO.Nome;
            aluno.Matricula = alunoDTO.Matricula;
            this.appContext.alunos.Add(aluno);
            this.appContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(AlunoDTO alunoDTO)
        {
            try
            {
                var aluno = this.appContext.alunos.Where(x => x.Id == alunoDTO.Id).FirstOrDefault();
                if (aluno != null)
                {
                    aluno.Nome = alunoDTO.Nome;
                    aluno.Matricula = alunoDTO.Matricula;
                    this.appContext.alunos.Update(aluno);
                    this.appContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario não existe!");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete("{id}")]
        public ActionResult Aniquilar(int id)
        {
            try
            {
                var aluno = this.appContext.alunos.Where(x => x.Id == id).FirstOrDefault();
                if (aluno != null)
                {
                    this.appContext.alunos.Remove(aluno);
                    appContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    throw new Exception("Usuario não existe!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
