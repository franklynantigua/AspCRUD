using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace AspCRUD.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria


        public ActionResult Index()
        {
            Gestor Gestor = new Gestor();
            ViewBag.ListadoCategoria = Gestor.LIstarCategorias(null);
            return View("Categoria");
        }

        public ActionResult opGuardar(Categoria obj)
        {  Gestor Gestor = new Gestor();
            if (obj.IdCategoria == 0)
            {
                //Insertar 
               
                Gestor.InsertarCategoria(obj);
            }
            else
            {
                //actualizar
            }
          
            ViewBag.ListadoCategoria = Gestor.LIstarCategorias(null);
            return View("Categoria");
        }

        public ActionResult GetCategoria(Int32 idCategoria)
        {
            Gestor gestor = new Gestor();
          ViewBag.Categoria= gestor.ObtenerCategorias(idCategoria);

            return Index();
        }
    }
}