﻿using ProyectoTurismo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTurismo.Controllers
{
    public class CuentaController : Controller
    {
        public DBTurismo db = new DBTurismo();
        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            Console.WriteLine("Hola");
            ViewBag.Message = "Bienvenido al Inicio Sesion";

            return View();
        }

        [HttpPost]
        public ActionResult Login(usuario usuario)
        {
            rol rol = db.rols.FirstOrDefault(r => r.Idrol == 1);
            rol rolUsuario = db.rols.FirstOrDefault(r => r.Idrol == 2);
            rol rolTecnico = db.rols.FirstOrDefault(r => r.Idrol == 3);
            var usr = db.usuarios.FirstOrDefault(u => u.username == usuario.username && u.contrasenia == usuario.contrasenia);

            if (usr != null && usr.rol == rol)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.dpi;
                Session["idRol"] = usr.idRol;
                return VerificarSesion();
            }
            else if (usr != null && usr.rol == rolUsuario)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.dpi;
                Session["idRol"] = usr.idRol;
                return VerificarSesionAgente();
            }
            else if (usr != null && usr.rol == rolTecnico)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.dpi;
                Session["idRol"] = usr.idRol;
                return VerificarSesionTecnico();
            }
            else {
                ModelState.AddModelError("", "Verifica tus credenciales");
            }
            return View();
        }
        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/AdministradorPanel");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult VerificarSesionAgente()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/AgentePanel");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult VerificarSesionTecnico()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/TecnicoPanel");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("IDUsuario");
            Session.Remove("nombreUsuario");
            return RedirectToAction("Login");
        }
    }
}