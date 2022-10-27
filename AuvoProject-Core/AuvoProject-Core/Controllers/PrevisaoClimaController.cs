using AuvoProject_Core.Context;
using AuvoProject_Core.Models;
using System.Net;
using System.Web.Mvc;

namespace AuvoProject_Core.Controllers
{
    public class PrevisaoClimaController : Controller
    {

        private ClimaTempoSimplesContext _db = new ClimaTempoSimplesContext();
        private readonly ILogger<PrevisaoClimaController> _logger;

        public PrevisaoClimaController(ILogger<PrevisaoClimaController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.Cidade = new SelectList(_db.Cidades, "Id", "Nome");
            ViewBag.Previsao = new SelectList(_db.PrevisaoClimas, "Clima", "temperaturaMinima", "temperaturaMaxima");
            return View(_db.PrevisaoClimas.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevisaoClima previsaoClima = _db.PrevisaoClimas.Find(id);

            if (previsaoClima == null)
            {
                return HttpNotFound();
            }
            return View(previsaoClima);
        }
    }
}
