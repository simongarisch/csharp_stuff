
namespace PdfHunter
{
    public class FileLink
    {
        public readonly string Name;
        public readonly string Link;

        public FileLink(string Name, string Link)
        {
            this.Name = Name;
            this.Link = Link;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Link}";
        }
    }
}
