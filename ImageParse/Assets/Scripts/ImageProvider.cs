using System.Collections.Generic;
using System.Net;
using HtmlAgilityPack;
using Parser;

public class ImageProvider 
{
    private readonly Dictionary<string, List<string>> _cachedImages = new();
    private readonly IParser<List<string>> _parser;

    public ImageProvider(IParser<List<string>> parser) 
        => _parser = parser;

    public List<string> GetAllImagesPath(string url)
    {
        if (_cachedImages.TryGetValue(url, out List<string> images))
            return images;

        WebClient client = new WebClient();
        string source = client.DownloadString(url);

        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(source);


        images = _parser.Parse(document);
        _cachedImages.Add(url, images);

        return images;
    }

}