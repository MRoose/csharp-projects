﻿using System;
using System.Collections.Generic;

namespace QuestCore
{
    /// <summary>
    /// Опросник.
    /// Содержит список вопросов.
    /// </summary>
    [Serializable]
    public class Questionnaire : List<Quest>
    {
    }

    /// <summary>
    /// Вопрос.
    /// Содержит список альтернатив.
    /// </summary>
    [Serializable]
    public class Quest : List<Alternative>
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public QuestType QuestType { get; set; }

        /// <summary>
        /// Условие показа
        /// </summary>
        public Condition Condition { get; set; }
    }

    /// <summary>
    /// Тип вопроса
    /// </summary>
    [Serializable]
    public enum QuestType
    {
        /// <summary>
        /// Выбор одной альтренативы из фиксированного списка альтернатив
        /// </summary>
        Выпадающий_список,
        /// <summary>
        /// Пользователь может вбить произвольный ответ в текстовое поле
        /// </summary>
        Строка_ввода
    }

    /// <summary>
    /// Альтернатива вопроса
    /// </summary>
    [Serializable]
    public class Alternative
    {
        /// <summary>
        /// Код альтернативы
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Текст альтернативы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Условие показа
        /// </summary>
        public Condition Condition { get; set; }
    }
}
