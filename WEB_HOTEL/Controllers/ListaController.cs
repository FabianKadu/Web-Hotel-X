using LibreriaClasesHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEB_HOTEL.Controllers
{
    public class ListaController : Controller
    {

        private readonly Hotel_XContext _context;
        public ListaController(Hotel_XContext contexto)
        {
            _context = contexto;
        }
        public async Task<IActionResult> Index()
        {
            var listaReservas = await _context.VistaReservaciones.ToListAsync();


            return View(listaReservas);
        }

    }
}
