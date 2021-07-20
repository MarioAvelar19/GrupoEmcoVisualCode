using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Controllers
{
    public class PropiedadController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PropiedadController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var propiedad = _db.Propiedades.FromSqlRaw("select * from Propiedades").ToList();
            return View(propiedad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string?estado,string?tipolocal,string?tipoO,int?min,int?max,int ?baños,int?cuartos)
        {
            int contador = 0;  
            var str = "select * from Propiedades where ";

            if(estado != "Ninguno")
            {   
                    str += "Estado ='" + estado + "'";
                    contador++ ;
            }

            if (tipolocal != "Ninguno")
            {

                if (contador == 0)
                {
                    str += "TipoPropiedad ='" + tipolocal + "'";
                    contador++;
                }
                else
                    str += "AND TipoPropiedad ='" + tipolocal + "'";
            }
        
            if(tipoO != null)
            {
                if (contador == 0)
                {
                    str += "tipoOperacion ='" + tipoO + "'";
                    contador++;
                }
                else
                    str += "AND tipoOperacion ='" + tipoO + "'";
            }
            if (min != null)
            {   if (contador == 0)
                {
                    str += "Precio >=" + min;
                    contador++;
                }
                else
                    str += "AND Precio >=" + min;
            }
            if (max != null)
            {   if (contador == 0)
                {
                    str += "Precio <=" + max;
                    contador++;
                }
                else
                    str += "AND Precio <=" + max;
            }
            if (baños != null)
            {
                if (contador == 0)
                {
                    str += "Baños =" + baños;
                    contador++;
                }
                else
                    str += "AND Baños =" + baños;

            }
            if (cuartos != null)
            {
                if (contador == 0)
                {
                    str += "Cuartos =" + cuartos;
                    contador++;
                }
                else
                    str += "AND Cuartos =" + cuartos;
            }

            if (str == "select * from Propiedades where ")
            {
                str = "select * from Propiedades";
            }


            var propiedad = _db.Propiedades.FromSqlRaw(str).ToList();
            return View(propiedad);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Propiedad obj)
        {
            if (ModelState.IsValid)
            {
                _db.Propiedades.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Propiedad");
            }
            return View(obj);
        }

        public IActionResult Eliminar( int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Propiedades.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarPropiedad(int ? id)
        {
            var obj = _db.Propiedades.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Propiedades.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Propiedad");
        }

        public IActionResult Actualizar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Propiedades.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizar(Propiedad obj)
        {
            if (ModelState.IsValid)
            {
                _db.Propiedades.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Propiedad");
            }
            return View(obj);
        }

    }
}
