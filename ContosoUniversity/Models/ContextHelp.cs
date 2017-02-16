using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ContosoUniversity.Models
{
    public class ContextHelp
    {
        public int ContextHelpID { get; set; }

        [Required]
        [StringLength(100)]
        public string Controller { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        [StringLength(100)]
        public string Property { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "Help Text")]
        public string HelpText { get; set; }

        [Display(Name = "Tooltip Text")]
        public string Tooltip { get; set; }
    }
}