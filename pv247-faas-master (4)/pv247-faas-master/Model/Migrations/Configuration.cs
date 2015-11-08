namespace Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.FormAsAServiceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.FormAsAServiceDbContext db)
        {
            var basicInfoFormType = new FormType { Name = "Basic personal information form." };
            var textNameType = new ElementType { Name = "Name", ElementHtmlType = ElementHtmlTypeEnum.TextBox };
            var textSurnameType = new ElementType { Name = "Surname", ElementHtmlType = ElementHtmlTypeEnum.TextBox };

            basicInfoFormType.ElementTypes.Add(textNameType);
            basicInfoFormType.ElementTypes.Add(textSurnameType);
            db.FormTypes.AddOrUpdate(basicInfoFormType);

            var johnDoeForm = new Form { Type = basicInfoFormType };
            johnDoeForm.Elements.Add(new Element { Type = textNameType, Value = "John" });
            johnDoeForm.Elements.Add(new Element { Type = textSurnameType, Value = "Doe" });
            db.Forms.AddOrUpdate(johnDoeForm);

            var janeRoeForm = new Form { Type = basicInfoFormType };
            janeRoeForm.Elements.Add(new Element { Type = textNameType, Value = "Jane" });
            janeRoeForm.Elements.Add(new Element { Type = textSurnameType, Value = "Roe" });
            db.Forms.AddOrUpdate(janeRoeForm);

            db.SaveChanges();
        }
    }
}
