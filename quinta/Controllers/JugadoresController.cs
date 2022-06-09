using quinta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace quinta.Controllers
{
    public class JugadoresController : Controller {
        // GET: Jugadores
        public ActionResult Index() {

            return View();
        }

        public ActionResult List_jugadores() 
        {
            using (var db = new lista_jugadoresEntities1())

            return View(db.jugadores.ToList());
            
        }
        public ActionResult Lista_jugadores() 
        {
            if (Session["contraseña"] == null)
            {
                return RedirectToAction("lista_jugadores");
            }
            else 
            {
                try 
                {
                   
                   using (var db = new lista_jugadoresEntities1())
                    {
                        List<jugadores> lista = null;
                        Session["lista_jugadores"] = lista;
                        return View(lista);
                    }

                }
                   catch (Exception)
                  {
                    throw;
                  }

            }

        }

        public ActionResult Agregar_Jugador() {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Jugador(jugadores j) {
            if (!ModelState.IsValid)
                return View();
            try {
                using (var db = new lista_jugadoresEntities1()) {
                    db.jugadores.Add(j);
                    db.SaveChanges();
                    return RedirectToAction("lista_jugadores");

                }
            }
            catch (Exception) {
                throw;
            }
        }

        public ActionResult Detalle_Jugador(int id) {

            try {
                using (var db = new lista_jugadoresEntities1()) {
                    jugadores Jugador = db.jugadores.Find(id);

                    return View(Jugador);

                }
            }
            catch (Exception ex) {
                ModelState.AddModelError("Error al mostrar detalles del jugador", ex);
                return RedirectToAction("lista_jugadores");
            }
        }
        public ActionResult Eliminar_Jugador(int id) {

            try {
                using (var db = new lista_jugadoresEntities1()) {
                    jugadores alu = db.jugadores.Find(id);
                    db.jugadores.Remove(alu);
                    db.SaveChanges();
                    return RedirectToAction("lista_jugadores");

                }
            }
            catch (Exception ex) {
                ModelState.AddModelError("Error al eliminar el jugador", ex);
                return RedirectToAction("lista_jugadores");
            }
        }
        public ActionResult Agregar_Jugador_Por_Clase() {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Jugador_Por_Clase(JugadoresCLS ojugadoresCLS) {
            if (!ModelState.IsValid)
                return View(ojugadoresCLS);
            try {
                using (var db = new lista_jugadoresEntities1()) {
                    jugadores ojugador = new jugadores {
                        apellido = ojugadoresCLS.apellido,
                        nombre = ojugadoresCLS.nombre
                    };
                    db.jugadores.Add(ojugador);
                    db.SaveChanges();
                    return RedirectToAction("lista_jugadores");

                }
            }
            catch (Exception) {
                throw;
            }
        }

        

    }
    }
