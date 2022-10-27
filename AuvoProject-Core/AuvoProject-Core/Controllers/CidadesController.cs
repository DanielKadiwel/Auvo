using AuvoProject_Core.Context;
using AuvoProject_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Mvc;
using ActionResult = System.Web.Mvc.ActionResult;
using Controller = System.Web.Mvc.Controller;

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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cidade cidade = _db.Cidades.Find(id);

            if (cidade.PrevisaoClimas.Any())
            {

            }

            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
