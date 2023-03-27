using HtmlAgilityPack;

namespace Parser
{
    public interface IParser<T> where T : class
    {
        T Parse(HtmlDocument document);
    }
}