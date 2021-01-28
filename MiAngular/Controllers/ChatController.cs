using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAngular.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


namespace MiAngular.Controllers
{
    //
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        // Se crea el contexto de la BD
        private Models.MyDBContext db;

        // Se crea el constructor de la BD.
        public ChatController(Models.MyDBContext context)
        {
            db = context;
        }

        //Metodo con Interfaz
        [HttpGet("[action]")]
        //Resultado de interface
        // public IActionResult Message()

            // Retorna tipo de dato MessageView
        public IEnumerable<MessageViewModel> Message()
        {
            //Genera una lista de la bd
            // List<Models.Message> lst = null;
            //lst = db.Message.ToList();
            // RETORNO DE JSON TABLA MESSAGE
            // return Json(lst);

            List<MessageViewModel> lst = (from d in db.Message
                                          select new MessageViewModel
                                          {
                                              Id = d.Id,
                                              Name = d.Name,
                                              Text = d.Text
                                          }).ToList();
            return lst;
        }
    }
}