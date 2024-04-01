using AngularApp.Server.Data;
using AngularApp.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("historico")]
    public class HistoricoController  : Controller
    {
        private readonly AppDbContext _context;

        public HistoricoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<HistoricoModel> GetAll()
        {
            return _context.Historicos.ToList();
        }
        [HttpPost]
        public async Task<HistoricoModel> CriarHistorico(HistoricoModel historico)
        {
            if (historico.Chute.Equals(historico.numeroSorteado))
            {
                historico.Resultado = Convert.ToInt32(EResultado.SUCCESS);
                await _context.AddAsync(historico);
                await _context.SaveChangesAsync();
                return historico;
            }
            else
            {
                historico.Resultado = Convert.ToInt32(EResultado.WRONG);
                await _context.AddAsync(historico);
                await _context.SaveChangesAsync();
                return historico;
            }
        }
        [HttpPost("retornaUltimo")]
        public async Task<IActionResult> RetornaUltimoHistorico(HistoricoModel historico)
        {
            int chuteRepetido;
            HistoricoModel historico2 = await _context.Historicos.Where(x => x.CodigoUsuario == historico.CodigoUsuario).OrderBy(e => e.Id).LastAsync();
            if(historico.Chute.Equals(historico2.Chute))
            {
                chuteRepetido = 1;
                return Ok(new { chuteRepetido});
            } else { chuteRepetido = 0; return Ok(new { chuteRepetido }); }
        }

        [HttpPost("criajogo")]
        public IActionResult CriaJogo(int dificuldade)
        {
            int numeroSorteado;
            int tentativa;
            if (dificuldade.Equals(1))
            { numeroSorteado = new Random().Next(0, 11); tentativa = 5; }
            else if (dificuldade.Equals(2))
            { numeroSorteado = new Random().Next(0, 26); tentativa = 4; }
            else { numeroSorteado = new Random().Next(0, 51); tentativa = 3; }
            return Ok(new { numeroSorteado, tentativa });
        }
        
        //Metodo para paginação!
        [HttpGet("skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetPaginado(
              int skip = 0,
              int take = 25)
          {
              var count = await _context.Historicos.CountAsync();
              var all = await _context
                  .Historicos
                  .AsNoTracking()
                  .Skip(skip)
                  .Take(take)
                  .ToListAsync();
        
              return Ok(new
              {
                  data = all,
                  count
              });
          }
    }
}
