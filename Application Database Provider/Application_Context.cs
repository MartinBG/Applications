using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using Application_Objects;

namespace Application_Database_Provider
{
    class Application_Context: DbContext
    { 
        public Application_Context()
            : base("name=Application")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Application> Applications { get; set; }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, System.Collections.Generic.IDictionary<object, object> items)
        {
            var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());

            //Sender
            if (entityEntry.Entity is Application)
            {
                Application current = entityEntry.Entity as Application;

                if (current.Sender == "")
                {
                    result.ValidationErrors.Add(new DbValidationError("Sender", "Application missing Sender!!!"));
                }
            }

            if (entityEntry.Entity is Application)
            {
                Application current = entityEntry.Entity as Application;

                if (current.Sender.Length > 30)
                {
                    result.ValidationErrors.Add(new DbValidationError("Subject", "Sender cannot be longer than 30 characters!!!"));
                }
            }

            //subject
            if (entityEntry.Entity is Application)
            {
                Application current = entityEntry.Entity as Application;

                if (current.Subject == "")
                {
                    result.ValidationErrors.Add(new DbValidationError("Subject", "Application missing subject!!!"));
                }
            }

            if (entityEntry.Entity is Application)
            {
                Application current = entityEntry.Entity as Application;

                if (current.Subject.Length > 30)
                {
                    result.ValidationErrors.Add(new DbValidationError("Subject", "Subject cannot be longer than 50 characters!!!"));
                }
            }

            

            //RegNum
            if (entityEntry.Entity is Application)
            {
                Application current = entityEntry.Entity as Application;

                if (current.Subject.Length > 20)
                {
                    result.ValidationErrors.Add(new DbValidationError("ReigistrationNumber", "RegistrationNumber cannot be longer than 20 characters!!!"));
                }
            }

            if (entityEntry.Entity is Application)
            {
                Application current = entityEntry.Entity as Application;

                if (current.Sender == "")
                {
                    result.ValidationErrors.Add(new DbValidationError("Sender", "Application missing registration number!!!"));
                }
            }

            

            if (result.ValidationErrors.Count > 0)
            {
                return result;
            }
            else
            {
                return base.ValidateEntity(entityEntry, items);
            }

        }

        public override int SaveChanges()
        {
            var errors = GetValidationErrors();

            bool hasError = false;

            foreach (var errs in errors)
            {
                hasError = true;
                foreach (var err in errs.ValidationErrors)
                {
                    Console.WriteLine(err.ErrorMessage);
                }
            }
            if (!hasError)
            {
                return base.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
