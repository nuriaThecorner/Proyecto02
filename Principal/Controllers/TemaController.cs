using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos.Datos;
using Datos.ViewModels;
using Servicios.TemasServices;

namespace Principal.Controllers
{
    public class TemaController : Controller
    {
        //private ProyectoMusicaDbContext db = new ProyectoMusicaDbContext();

        // GET: Temas
        public ActionResult Index(int? id, string madre, string nombreMadre)
        {
            //Necesitamos un IList<Pedido> para pasárselo a la View
            IList<Tema> temas = null;
            //Creamos un objeto de la Clase PedidosService
            TemasService service = null;
            service = new TemasService();
            //Lo utilizamos para llegar a su método List 
            //Y, así rellenar nuestro IList<DetallePedido> pedidos
            temas = service.List(id, madre);

            ViewBag.Message = "";
            if (madre != null && madre != "")
            {
                ViewBag.Message = "Temas del " + madre + ": " + nombreMadre;

            }
            return View(temas);
        }

        // GET: Temas/Details/5
        public ActionResult Details(int? id)
        {
            //Esto como estaba:
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //hasta aquí
            //Nuevo
            //Necesitamos un objeto Pedido para pasárselo a la View
            Tema tema = null;
            //Creamos un objeto de la Clase PedidosService
            TemasService service = null;
            service = new TemasService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Tema tema
            tema = service.Detail(id.Value);
            //Fin Nuevo
            //Esto como estaba:
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
            //hasta aquí
        }

        // GET: Temas/Create 
        public ActionResult Create()
        {
            DiscosTemas viewModel = null;

            TemasService service = null;
            service = new TemasService();

            viewModel = service.RellenaViewModel();
            //ViewBag.CustomerID = SelectListsClienteRellenator(null);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(null);
            //ViewBag.shipperID = SelectListsNavieraRellenator(null);
            return View(viewModel);
        }

        // POST: Temas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscosTemas viewModel)
        {

            TemasService service = null;
            if (ModelState.IsValid)
            {
                service = new TemasService();
                bool ok = false;
                ok = service.Create(viewModel.temas);
                if (ok == true)
                {
                    //Si esto sucede, entonces llama al método "Index"
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Message = "Las Cagao";

            //ViewBag.CustomerID = SelectListsClienteRellenator(viewModel.pedido.CustomerID);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(viewModel.pedido.EmployeeID);
            //ViewBag.shipperID = SelectListsNavieraRellenator(viewModel.pedido.shipperID);

            //ClientesEmpleadosNavierasPedidoViewModel1 viewModel = null;
            viewModel = service.RellenaViewModel();
            viewModel.temas = viewModel.temas;

            return View(viewModel);
        }

        // GET: Temas/Edit/5
        public ActionResult Edit(int? id)
        {


            DiscosTemas viewModel = null;

            TemasService service = null;
            service = new TemasService();

            viewModel = service.RellenaViewModel();

            Tema tema = null;
            tema = service.Detail(id.Value);
            viewModel.temas = tema;

            //ViewBag.CustomerID = SelectListsClienteRellenator(pedido.CustomerID);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(pedido.EmployeeID);
            //ViewBag.shipperID = SelectListsNavieraRellenator(pedido.shipperID);

            return View(viewModel);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiscosTemas viewModel)
        {
            //ESTE OBJETO tema que ha entrado es NUEVO
            //para comprobarlo, buscamos el que está en la Tabla Pedido
            if (ModelState.IsValid)
            {
                TemasService service = new TemasService();
                bool ok = false;
                //Vamos a testear el registro que hay en la tabla:
                Tema buscada = service.Detail(viewModel.temas.id);
                //Vemos los valores de el objeto Tema buscada
                //id = 9
                //name = Bicho
                //description = Cambiamos la descripción
                //El registro de dentro de la Tabla Tema NO HA CAMBIADO. PORQUE ES OTRO

                ok = service.Edit(viewModel.temas);
                if (ok == true)
                {
                    //Si esto sucede, entonces llama al método "Index"
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Message = "Las Cagao";
            //ViewBag.CustomerID = SelectListsClienteRellenator(pedido.CustomerID);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(pedido.EmployeeID);
            //ViewBag.shipperID = SelectListsNavieraRellenator(pedido.shipperID);

            return View(viewModel);
        }

        // GET: Temas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Nuevo
            //Necesitamos un objeto Pedido para pasárselo a la View
            Tema tema = null;
            //Creamos un objeto de la Clase PedidosService
            TemasService service = null;
            service = new TemasService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Tema pedido
            tema = service.Detail(id.Value);
            //Fin Nuevo
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            //Nuevo
                     //Necesitamos un objeto Pedido para pasárselo a la View
            Tema tema = null;
            //Creamos un objeto de la Clase PedidosService
            TemasService service = null;
            service = new TemasService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Tema tema
            tema = service.Detail(id);
            //Fin Nuevo
            bool ok = false;
            ok = service.Delete(tema);

            return RedirectToAction("Index");
        }
        //SelectListsRellenators
        //private SelectList SelectListsPedidoRellenator(int? id)
        //{
        //    DetallesPedidosService service = null;
        //    service = new DetallesPedidosService();
        //    IList<Pedido> pedidos = null;
        //    pedidos = service.List(null);
        //    SelectList selectList = null;
        //    if (id != null && id > 0)
        //    {
        //        selectList = new SelectList(pedidos, "OrderID", "OrderDate", id);
        //    }
        //    else
        //    {
        //        selectList = new SelectList(pedidos, "OrderID", "OrderDate");
        //    }

        //    return selectList;
        //}

        //private SelectList SelectListsProductoRellenator(int? id)
        //{
        //    DetallesPedidosService service = null;
        //    service = new DetallesPedidosService();
        //    IList<Producto> productos = null;
        //    productos = service.List(null);
        //    SelectList selectList = null;
        //    if (id != null && id > 0)
        //    {
        //        selectList = new SelectList(productos, "ProductID", "ProductName", id);
        //    }
        //    else
        //    {
        //        selectList = new SelectList(productos, "ProductID", "ProductName");
        //    }

        //    return selectList;
        //}




        protected override void Dispose(bool disposing)
        {
            //bool ok = false;
            ////Creamos un objeto de la Clase PedidosService
            //PedidosService service = null;
            //service = new PedidosService();
            ////Lo utilizamos para llegar a su método Dispose 
            //ok = service.Dispose(disposing);

            //base.Dispose(disposing);
        }
    }
}
