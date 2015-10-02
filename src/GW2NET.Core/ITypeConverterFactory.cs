namespace GW2NET
{
    using GW2NET.Common;

    /// <summary>Provides the interface for converter factories that create a type converter for a given type discriminator.</summary>
    public interface ITypeConverterFactory<TSource, TTarget>
    {
        /// <summary>Creates an object that can convert the source type to the target type.</summary>
        /// <param name="discriminator">A type discriminator that is used to select the right converter.</param>
        /// <returns>An object that can convert the specified type.</returns>
        IConverter<TSource, TTarget> Create(string discriminator);
    }
}