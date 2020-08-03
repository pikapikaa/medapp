using System;
using System.ComponentModel;

namespace MedExpertClientClone.Models
{
    public enum AnswerType
    {
        /// <summary>
        /// Да
        /// </summary>
        [Description("Да")]
        Yes = 1,

        /// <summary>
        /// Нет
        /// </summary>
        [Description("Нет")]
        No = 2,

        /// <summary>
        /// Не применимо
        /// </summary>
        [Description("Не применимо")]
        InApplicable = 3,
    }
}
