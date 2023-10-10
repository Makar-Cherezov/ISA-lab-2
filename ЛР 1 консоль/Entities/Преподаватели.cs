using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class Преподаватели
{
    public Guid IdПреподавателя { get; set; }

    public Guid IdИнститута { get; set; }

    public string Фамилия { get; set; }

    public string Имя { get; set; }

    public string Отчество { get; set; }

    public string Должность { get; set; }

    public string УчёноеЗвание { get; set; }

    public string СемейноеПоложение { get; set; }

    public virtual Институты IdИнститутаNavigation { get; set; }

    public virtual ICollection<ДисциплинаВСеместре> ДисциплинаВСеместреs { get; set; } = new List<ДисциплинаВСеместре>();
}
