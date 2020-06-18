using System;
using System.ComponentModel;

namespace MedExpertClientClone.Models
{
    public enum CalendarType
    {
        /// <summary>
        /// Начало периода
        /// </summary>
        [Description("Начало периода")]
        StartDate = 1,

        /// <summary>
        /// Конец периода
        /// </summary>
        [Description("Конец периода")]
        EndDate = 2,

        /// <summary>
        /// Не опеределен
        /// </summary>
        [Description("Не опеределен")]
        UndefinedDate = 2,
    }
}
