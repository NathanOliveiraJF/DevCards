using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCards.API.InputModels
{
    public class UpdateCarInputModel
    {
        //informacoes que realmente podem ser atualizados
        //usuario gerenciador da empresa.
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
