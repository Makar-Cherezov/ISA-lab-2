using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class Группы
{
    public Guid IdГруппы { get; set; }

    public Guid IdИнститута { get; set; }

    public string Наименование { get; set; }

    public int ГодПоступления { get; set; }

    public int ДлительностьОбучения { get; set; }

    public int КодФормыОбучения { get; set; }

    public string КодНаправленияПодготовки { get; set; }

    public virtual Институты IdИнститутаNavigation { get; set; }

    public virtual ICollection<ДисциплинаВСеместре> ДисциплинаВСеместреs { get; set; } = new List<ДисциплинаВСеместре>();

    public virtual НаправлениеПодготовки КодНаправленияПодготовкиNavigation { get; set; }

    public virtual ФормыОбучения КодФормыОбученияNavigation { get; set; }

    public virtual ICollection<СтудентыВГруппах> СтудентыВГруппахs { get; set; } = new List<СтудентыВГруппах>();
}
