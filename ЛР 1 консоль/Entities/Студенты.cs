using Server;
using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class Студенты : IDataStructure
{
    public Guid IdСтудента { get; set; }

    public string Фамилия { get; set; }

    public string Имя { get; set; }

    public string Отчество { get; set; }

    public bool Пол { get; set; }

    public string АдресПроживания { get; set; }

    public DateTime ДатаРождения { get; set; }

    public int КодСтудента { get; set; }

    public virtual Справочник КодСтудентаNavigation { get; set; }

    public virtual ICollection<СтудентыВГруппах> СтудентыВГруппахs { get; set; } = new List<СтудентыВГруппах>();

    public List<string> GetPrintableStrings()
    {
        List<string> studentList = new()
            {
            IdСтудента.ToString(),
            Фамилия,
            Имя,
            Отчество is null? "БЕЗОТЧЕСТВОВИЧ(ВНА)":Отчество,
            Пол ? "Мужской" : "Женский",
            АдресПроживания,
            ДатаРождения.ToString("d"),
            КодСтудента.ToString()
            };
        return studentList;
    }
}
