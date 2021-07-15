using System.Collections.Generic;

namespace PdfHunter
{
    public interface IUrlModification
    {
        string Modify(string URL);
    }

    public class GithubBlob : IUrlModification
    {
        public string Modify(string URL)
        {
            return URL.Replace("/blob/", "/raw/");
        }
    }

    public class UrlModifications
    {
        private List<IUrlModification> _modifications;

        public UrlModifications(params IUrlModification[] modifications)
        {
            _modifications = new List<IUrlModification>(modifications);
        }

        public void Register(IUrlModification modification)
        {
            _modifications.Add(modification);
        }
        
        public string Apply(string URL)
        {
            foreach(var modification in _modifications)
            {
                URL = modification.Modify(URL);
            }

            return URL;
        }
    }
}
