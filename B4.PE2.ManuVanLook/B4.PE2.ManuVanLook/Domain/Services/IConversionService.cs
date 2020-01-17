namespace B4.PE2.ManuVanLook.Domain.Services
{
    /// <summary>
    ///  interface for the conversion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    public interface IConversionService<T, E>
    {
        double Convert(T obj);
        double ConvertFromBase(T obj);
        double TurnIntoBase(double basisEenheid, E eenheid);
    }
}
