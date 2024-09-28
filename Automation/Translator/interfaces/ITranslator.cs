namespace Translator.interfaces;

internal interface ITranslator<S,D>
{
    public Task<D> Translate(S source);
}
