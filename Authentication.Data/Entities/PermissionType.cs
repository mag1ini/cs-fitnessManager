using System.ComponentModel.DataAnnotations;


namespace Authentication.Data.Entities
{
    public enum PermissionType 
    {
        [Display(Name = "Назначить себе тренировку")]
        AssignTrainingToSelf = 1,

        [Display(Name = "Редактировать информацию о себе")]
        EditOwnProfile,

        [Display(Name = "Назначить тренировки")]
        AssignTrainings,

        [Display(Name="Добавить инфу о тренерах")]
        AddCoaches,

        [Display(Name = "Редактировать инфу о тренерах")]
        ManageCoaches,

        [Display(Name = "Добавить инфу о залах")]
        AddHalls,

        [Display(Name = "Редактировать инфу о тренерах")]
        ManageHalls,

        [Display(Name = "Добавить инфу о тренировках")]
        AddTrainings,

        [Display(Name = "Редактировать инфу о тренировках")]
        ManageTrainings,
        
        [Display(Name = "Добавить инфу о клиентах")]
        AddClients,

        [Display(Name = "Редактировать инфу о клиентах")]
        ManageClients,
        
        [Display(Name = "Добавить инфу о менеджерах")]
        AddManagers,

        [Display(Name = "Редактировать инфу о менеджерах")]
        ManageManagers,

    }
}
