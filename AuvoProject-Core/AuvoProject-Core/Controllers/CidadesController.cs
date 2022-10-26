using AuvoProject_Core.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
namespace AuvoProject_Core.Controllers
{
    public class CidadesController : Controller
    {
        private ClimaTempoSimplesContext _db = new ClimaTempoSimplesContext();
        private readonly ILogger<CidadesController> _logger;

        public CidadesController(ILogger<CidadesController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            var cidades = _db.Cidades.Include(x => x.Estado);
            return View(cidades.ToList());
        }



    }
}
