using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Parser
{
    public class ImageParser : IParser<List<string>>
    {
        public List<string> Parse(HtmlDocument document)
            => document.DocumentNode.Descendants("img")
                .Select(i => i.Attributes["src"])
                .Select(link => link.Value)
                .ToList();
    }
}