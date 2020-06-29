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

        /// <summary>
        /// Сообщение события сортировки по возрастанию
        /// </summary>
        public const string AscendingSort = nameof(AscendingSort);

        /// <summary>
        /// Сообщение события сортировки по убыванию
        /// </summary>
        public const string DescendingSort = nameof(DescendingSort);

        /// <summary>
        /// Сообщение события сортировки по дате
        /// </summary>
        public const string DateSort = nameof(DateSort);

        /// <summary>
        /// Сообщение события сортировки по умолчанию
        /// </summary>
        public const string DefaultSort = nameof(DefaultSort);

        /// <summary>
        /// Сообщение события добавления пользователя
        /// </summary>
        public const string AddEmployeers = nameof(AddEmployeers);

        /// <summary>
        /// Сообщение события добавления председателя
        /// </summary>
        public const string AddChairman = nameof(AddChairman);

        /// <summary>
        /// Сообщение события добавления чек-листа
        /// </summary>
        public const string AddCheckLists = nameof(AddCheckLists);

        /// <summary>
        /// Сообщение события добавления предмета проверки
        /// </summary>
        public const string AddAuditSubject = nameof(AddAuditSubject);
    }
}
