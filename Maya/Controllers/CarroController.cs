using Maya.Data;
using Maya.Models;
using Maya.Models.ViewModels;
using Maya.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Maya.Controllers
{
    public class CarroController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty] //para usar la propiedad en todo el controlador y no se pierdan sus valores
        public ProductoUsuarioVM productoUsuarioVM { get; set; }

        public CarroController(ApplicationDbContext db)
        {
            _db = db;
        }

        public object Httpcontext { get; private set; }


        //Get
        public IActionResult Index()
        {
            List<CarroCompra> carroCompraList = new List<CarroCompra>();
            
            if(HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras)!=null && 
               HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count()>0)
            {
                carroCompraList = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            List<int> prodEnCarro = carroCompraList.Select(i=>i.ProductoId).ToList();
            IEnumerable<Producto> prodList = _db.Producto.Where(p => prodEnCarro.Contains(p.Id));

            return View(prodList);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return RedirectToAction(nameof(Resumen));
        }

        //Get Resumen
        public IActionResult Resumen()
        {
            //Traer el Usuario Conectado
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //

            List<CarroCompra> carroCompraList = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null &&
               HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroCompraList = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            List<int> prodEnCarro = carroCompraList.Select(i => i.ProductoId).ToList();
            IEnumerable<Producto> prodList = _db.Producto.Where(p => prodEnCarro.Contains(p.Id));

            productoUsuarioVM = new ProductoUsuarioVM()
            {
                UsuarioAplicacion = _db.UsuarioAplicacion.FirstOrDefault(u => u.Id == claim.Value),
                ProductoLista = prodList.ToList(),
            };
            return View(productoUsuarioVM);

        }

        //Post Resumen
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Resumen")]
        public IActionResult ResumenPost(ProductoUsuarioVM productoUsuarioVM)
        {
            return RedirectToAction(nameof(Confirmacion));
        }

        public IActionResult Confirmacion()
        {
            HttpContext.Session.Clear();
            return View();
        }
        public IActionResult Remover(int Id)
        {
            List<CarroCompra> carroCompraList = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null &&
               HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroCompraList = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            carroCompraList.Remove(carroCompraList.FirstOrDefault(p => p.ProductoId == Id));
            HttpContext.Session.Set(WC.SessionCarroCompras, carroCompraList);

            return RedirectToAction(nameof(Index));
        }
    }
}
