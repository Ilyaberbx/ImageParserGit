using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageCreator : MonoBehaviour
    {
        [SerializeField] private RawImage _template;

        private List<RawImage> _images = new();

        public void Clear()
        {
            foreach (var image in _images) 
                Destroy(image.gameObject);
            
            _images = new();
        }

        public RawImage CreateImage()
        {
            var image = Instantiate(_template, transform.position, Quaternion.identity, transform);
            _images.Add(image);
            return image;
        }
    }
}