using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum LocationTypeEnum
    {
        [Display(Name = "Building / Land Mark")]
        BuildingLandMark = 1,

        [Display(Name = "Settlement")]
        Settlement = 2,

        [Display(Name = "Geography")]
        Geography = 3,
    }
}
