using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;

namespace B4.PE2.ManuVanLook.Domain.Models.Conversions
{
    public class ConversionTijd : ConversionBase
    {
        public TijdsEenheid TijdseenheidHerkomst { get; set; }
        public TijdsEenheid TijdseenheidToekomst { get; set; }
    }
}
