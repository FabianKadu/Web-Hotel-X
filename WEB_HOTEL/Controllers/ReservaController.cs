using Humanizer.Localisation;
using LibreriaClasesHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WEB_HOTEL.Controllers
{
    public class ReservaController : Controller
    {
        private readonly Hotel_XContextProcedures _context;
        public ReservaController(Hotel_XContextProcedures contexto) { 
            _context = contexto;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(string apellido, string nombre, string email, string dni, string telefono, int dias_estancia, DateTime fecha_inicio, int numero_habitacion)
        {
            if (ModelState.IsValid) // Asegurarse de que los datos sean válidos
            {
                {
                    await _context.InsertarDatosReservacionAsync(
                        apellido, 
                        nombre,
                        dni,
                        email,
                        telefono,
                        numero_habitacion,
                        fecha_inicio,
                        dias_estancia
                        
                    // Otros campos aquí...
                    );

                    return RedirectToAction("Index"); // O redirige a donde sea necesario
                }
            }

            return View(); // Si los datos no son válidos, vuelve a mostrar el formulario
            //await _context.InsertarDatosReservacionAsync();
            //await _context2.SaveChangesAsync();
            //return RedirectToAction("Index");
        }

    }
}
