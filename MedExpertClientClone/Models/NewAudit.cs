﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace MedExpertClientClone.Models
{
    /// <summary>
    /// Модель записи новой операции аудита
    /// </summary>
    public class NewAudit
    {
        /// <summary>Начало периода операции аудита</summary>
        public DateTime PeriodDateIn { get; set; }

        /// <summary>Окончание периода операции аудита</summary>
        public DateTime PeriodDateOut { get; set; }

        /// <summary>Язык и региональне парамметрв</summary>
        private CultureInfo Culture { get; set; } = new CultureInfo("ru", false);

        ///// <summary>
        ///// Текстовое представление начала периода операции аудита
        ///// </summary>
        //public string PeriodDateInText
        //{
        //    get { return $"{PeriodDateIn:dd.MM.yyyy} г."; }
        //}

        ///// <summary>
        ///// Текстовое представление окончания периода операции аудита
        ///// </summary>
        //public string PeriodDateOutText
        //{
        //    get { return $"{PeriodDateOut:dd.MM.yyyy} г."; }
        //}

        //protected void OnChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
