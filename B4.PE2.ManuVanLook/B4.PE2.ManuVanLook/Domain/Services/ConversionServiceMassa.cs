using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;
using B4.PE2.ManuVanLook.Domain.Models.Conversions;

namespace B4.PE2.ManuVanLook.Domain.Services
{
    /// <summary>
    ///  as an example of the interface implementation of Iconversionservice
    /// </summary>
    public class ConversionServiceMassa : IConversionService<ConversionMassa, MassaEenheid>
    {
        public double Convert(ConversionMassa conv)
        {
            double seconds = ConvertFromBase(conv);
            return TurnIntoBase(seconds, conv.MassaEenheidHerkomst);
        }

        public double TurnIntoBase(double gram, MassaEenheid eenheid)
        {
            switch (eenheid)
            {
                case MassaEenheid.gram:
                    return gram / 1;
                case MassaEenheid.kilogram:
                    return gram / 1000;
                case MassaEenheid.ton:
                    return gram / 1000000;
                case MassaEenheid.megaton:
                    return gram / 1000000000000;
                case MassaEenheid.gigaton:
                    return gram / 1000000000000000;
            }
            return double.NaN;

        }

        public double ConvertFromBase(ConversionMassa conv)
        {
            double herkomst = conv.HerkomstGetal;

            switch (conv.MassaEenheidToekosmt)
            {
                case MassaEenheid.gram:
                    conv.ToekomstGetal = herkomst * 1;
                    return conv.ToekomstGetal;
                case MassaEenheid.kilogram:
                    conv.ToekomstGetal = herkomst * 1000;
                    return conv.ToekomstGetal;
                case MassaEenheid.ton:
                    conv.ToekomstGetal = herkomst * 1000000;
                    return conv.ToekomstGetal;
                case MassaEenheid.megaton:
                    conv.ToekomstGetal = herkomst * 1000000000000;
                    return conv.ToekomstGetal;
                case MassaEenheid.gigaton:
                    conv.ToekomstGetal = herkomst * 1000000000000000;
                    return conv.ToekomstGetal;
            }
            return double.NaN;

        }
    }

}
