using System.Collections.Generic;
using ContosoUniversity.Models;

namespace ContosoUniversity.ViewModels
{
    public class ContextHelpWithHelp
    {
        public IEnumerable<ContextHelp> ContextHelps { get; set; }
        public IEnumerable<ContextHelp> ContextHelpList { get; set; }
        public ContextHelp ContextHelp { get; set; }
    }
}