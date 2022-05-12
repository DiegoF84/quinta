using quinta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace quinta.Controllers
{
    public class JugadoresController : Controller
    {
        // GET: Jugadores
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Lista_jugadores()
        {
            using (var db = new lista_jugadoresEntities())

                return View(db.jugadores.ToList());
        }
        public ActionResult Agregar_Jugador()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Jugador(jugadores j)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new lista_jugadoresEntities())
                {
                    db.jugadores.Add(j);
                    db.SaveChanges();
                    return RedirectToAction("lista_jugadores");

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Detalle_Jugador(int id)
        {
            
            try
            {
                using (var db = new lista_jugadoresEntities())
                {
                    jugadores Jugador = db.jugadores.Find(id);
                   
                    return View(Jugador);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al mostrar detalles del jugador", ex);
                return RedirectToAction("lista_jugadores");
            }
        }
        public ActionResult Eliminar_Jugador(int id)
        {

            try
            {
                using (var db = new lista_jugadoresEntities())
                {
                    jugadores alu = db.jugadores.Find(id);
                    db.jugadores.Remove(alu);
                    db.SaveChanges();
                    return RedirectToAction("lista_jugadores");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al eliminar el jugador", ex);
                return RedirectToAction("lista_jugadores");
            }
        }
        public ActionResult Agregar_Jugador_Por_Clase()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Jugador_Por_Clase(JugadoresCLS ojugadoresCLS)
        {
            if (!ModelState.IsValid)
                return View(ojugadoresCLS);
            try
            {
                using (var db = new lista_jugadoresEntities())
                {
                    jugadores ojugador = new jugadores();
                    ojugador.apellido = ojugadoresCLS.apellido;
                    ojugador.nombre = ojugadoresCLS.nombre;
                    db.jugadores.Add(ojugador);
                    db.SaveChanges();
                    return RedirectToAction("lista_jugadores");

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Login() {

            return View();
        }

        public ActionResult Login(usuario objUser)
        {
            if (!ModelState.IsValid)
                using (lista_jugadoresEntities db = new lista_jugadoresEntities())
                    {
                    var obj = db.usuario.Where(a => a.nombre.Equals(objUser.nombre) && a.clave.Equals(objUser.clave)).FirstOrderDefault();
                    if(objUser!=null) 
                    {
                        Session["UserID"] = obj.id_usuario.ToString();
                        Session["UserName"] = obj.nombre.ToString();
                    }

                }
            return View(objUser);
        }

        public ActionResult Logaut() {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
        
           




    }
}
