using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;

namespace B4.PE2.ManuVanLook.Domain.Models.Conversions
{
    public class ConversionMassa : ConversionBase
    {
        public MassaEenheid MassaEenheidHerkomst { get; set; }
        public MassaEenheid MassaEenheidToekosmt { get; set; }
    }
}
