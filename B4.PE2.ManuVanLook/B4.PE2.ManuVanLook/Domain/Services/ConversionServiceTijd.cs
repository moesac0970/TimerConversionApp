using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;
using B4.PE2.ManuVanLook.Domain.Models.Conversions;

namespace B4.PE2.ManuVanLook.Domain.Services
{
    /// <summary>
    /// class for fast conversion of time entity
    /// conversion service that is easy to expand 
    /// </summary>
    public class ConversionServiceTijd : IConversionService<ConversionTijd, TijdsEenheid>
    {

        // ref rofl rofl pindakaas
        public double Convert(ConversionTijd conv)
        {
            double seconds = ConvertFromBase(conv);
            conv.ToekomstGetal = TurnIntoBase(seconds, conv.TijdseenheidToekomst);
            return conv.ToekomstGetal;
        }

        // ref rofl lol
        public double TurnIntoBase(double seconds, TijdsEenheid eenheid)
        {
            switch (eenheid)
            {
                case TijdsEenheid.seconds:
                    return seconds / 1;
                case TijdsEenheid.minutes:
                    return seconds / 60;
                case TijdsEenheid.hours:
                    return seconds / (60 * 60);
                case TijdsEenheid.days:
                    return seconds / (60 * 60 * 24);
            }
            return double.NaN;
        }

        // ref lolololol
        public double ConvertFromBase(ConversionTijd conv)
        {
            double Toekomst;

            if (conv.TijdseenheidHerkomst == TijdsEenheid.seconds)
            {
                Toekomst = conv.HerkomstGetal * 1;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.minutes)
            {
                Toekomst = conv.HerkomstGetal * 60;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.hours)
            {
                Toekomst = conv.HerkomstGetal * 60 * 60;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.days)
            {
                Toekomst = conv.HerkomstGetal * 60 * 60 * 24;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.month)
            {
                Toekomst = conv.HerkomstGetal * 60 * 60 * 24 * 30;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.year)
            {
                Toekomst = conv.HerkomstGetal * 60 * 60 * 24 * 30 * 12;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.decenia)
            {
                Toekomst = conv.HerkomstGetal * 60 * 60 * 24 * 30 * 12 * 10;
                return Toekomst;
            }
            if (conv.TijdseenheidHerkomst == TijdsEenheid.millenia)
            {
                Toekomst = conv.HerkomstGetal * 60 * 60 * 24 * 30 * 12 * 1000;
                return Toekomst;
            }
            else
            {
                return double.NaN;
            }
        }


    }
}
