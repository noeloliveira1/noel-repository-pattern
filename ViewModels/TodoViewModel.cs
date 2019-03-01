using System.ComponentModel;

namespace noel_repository_pattern.ViewModels
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        // [DisplayName("What should I do")]
        public string What { get; set; }
        public bool Done { get; set; }
    }
}