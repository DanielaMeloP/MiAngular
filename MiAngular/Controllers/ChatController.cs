using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAngular.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MiAngular.Models.Response;

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
          
            List<MessageViewModel> lst = (from d in db.Message
                                          orderby d.Id descending
                                          select new MessageViewModel
                                          {
                                              Id = d.Id,
                                              Name = d.Name,
                                              Text = d.Text
                                          }).ToList();
            return lst;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]MessageViewModel model)
        {
            MyResponse oR = new MyResponse();
            try
            {
                Models.Message oMessage = new Models.Message();
                oMessage.Name = model.Name;
                oMessage.Text = model.Text;
                db.Message.Add(oMessage);
                db.SaveChanges();


                oR.Success = 1;
                oR.Message = "Dato creado exitosamente";


            }
            catch (Exception ex)
            {
                oR.Success = 0;
                oR.Message = ex.Message;
            }

            return oR;
        }
    }
}