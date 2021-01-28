using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace MiAngular.Models.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
