using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CampaignRoleEnum
    {
        [Display(Name = "Player")]
        Player = 1,

        [Display(Name = "Game Master")]
        GameMaster = 2
    }
}
