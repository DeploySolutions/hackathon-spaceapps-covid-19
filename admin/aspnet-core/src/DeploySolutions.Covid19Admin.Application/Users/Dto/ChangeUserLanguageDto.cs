using System.ComponentModel.DataAnnotations;

namespace DeploySolutions.Covid19Admin.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}