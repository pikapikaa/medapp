using System;
namespace MedExpertClientClone.ViewModels.Base
{
    /// <summary>
    /// Класс ключей сообщений для MessageCenter
    /// </summary>
    public static class MessageKeys
    {
        /// <summary>
        /// Сообщение события изменения даты начала проверок
        /// </summary>
        public const string StartDateAudit = nameof(StartDateAudit);

        /// <summary>
        /// Сообщение события изменения даты окончания проверок
        /// </summary>
        public const string EndDateAudit = nameof(EndDateAudit);
    }
}
