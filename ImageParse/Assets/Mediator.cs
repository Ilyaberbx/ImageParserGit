using System.Collections.Generic;
using Parser;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Mediator : MonoBehaviour
{
    [SerializeField] private ImageCreator _creator;
    [SerializeField] private SearchButton _searchButton;
    [SerializeField] private ResultsCount _resultsCount;
    
    private IParser<List<string>> _parser;
    private ImageLoadByUrl _imageLoader;
    private ImageRequester _requester;

    private void Awake()
    {
        _searchButton.OnSearched += Search;
        _imageLoader = new ImageLoadByUrl();
        _parser = new ImageParser();
        _requester = new ImageRequester(_parser);
    }

    private void OnDestroy()
        => _searchButton.OnSearched -= Search;

    private void Search(string url)
    {
        _creator.Clear();
        
        List<string> imagesPath = _requester.GetAllImagesPath(url);

        foreach (var path in imagesPath)
        {
            var image = _creator.CreateImage();
            SetImageTexture(url, path, image);
        }
        _resultsCount.UpdateResultCount(imagesPath.Count);
    }

    private void SetImageTexture(string url, string path, RawImage image) 
        => StartCoroutine(_imageLoader.SetImageTextureByUrl(url + path, image));
}