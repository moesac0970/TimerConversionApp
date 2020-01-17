using B4.PE2.ManuVanLook.Domain.Models.Conversions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace B4.PE2.ManuVanLook.Domain.Validators
{
    public class ConversionValidator
    {
        public List<ValidationResult> Validate(ConversionTijd conv)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (conv.HerkomstGetal == double.NaN) { results.Add(new ValidationResult("input is empty")); }
            if (conv.TijdseenheidHerkomst == conv.TijdseenheidToekomst) { results.Add(new ValidationResult("herkomst en toekomst zijn hetzelfde")); }
            if (conv.HerkomstGetal == 666.666) { results.Add(new ValidationResult("herkomst is duivelig, dat gaat ni lukken eh geen huidense zaken in deze app")); }
            // configure more rules 

            return results;
        }
    }
}
