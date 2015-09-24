using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application_Objects;
using System.Data.Entity;

namespace Application_Database_Provider.Repository
{
    public class ApplicationRepository
    {
        private Application_Context Context = new Application_Context();

        private bool isIdCorrect(int id)
        {
            try
            {
                int lastId = getAllActiveApplications().Where(a => a.Id == id).Select(a => a.Id).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine("No application with such id!");
                return false;
            }

            return true;

        }

        //GET
        public IEnumerable<Application> getAllApplications()
        {
            return Context.Applications;
        }

        public IEnumerable<Application> getAllActiveApplications()
        {
            return getAllApplications().Where(a => a.IsActive).Select(a => a);
        }

        public IEnumerable<Application> getInactiveApplications()
        {
            return getAllApplications().Where(a => a.IsActive == false).Select(a => a);
        }

        public Application getApplicationById(int Id)
        {
            Application ApplicationById;

            if (isIdCorrect(Id))
            {
                ApplicationById = getAllActiveApplications().Where(c => c.Id == Id)
                    .Select(c => c)
                    .Single();

                return ApplicationById;
            }
            else
            {
                Console.WriteLine("Error in retrieval! Check Id or Database!");
                return new Application();
            }

        }

        
        //POST
        public IEnumerable<Application> filterApplications(FilterObject filter)
        {
            var applications = getAllActiveApplications();
            if (filter != null)
            {
                if (filter.subject != "" && filter.subject != null)
                {
                    applications = applications.Where(a => a.Subject.Contains(filter.subject));
                }
                if (filter.newInterval != null)
                {
                    if (filter.newInterval.startDate != null)
                    {
                        applications = applications.Where(a => a.PostDate > filter.newInterval.startDate);
                    }
                    if (filter.newInterval.endDate != null)
                    {
                        applications = applications.Where(a => a.PostDate < filter.newInterval.endDate);
                    }
                }
            }
            return applications;
        }

        public string postApplication(Application newApplication)
        {
            if (newApplication != null)
            {

                string RegNum = "";
                if (getAllApplications().ToList().Count == 0)
                {
                    RegNum = "1-{";

                }
                else
                {
                    var LastApplication = getAllApplications().Select(a => a).Last();
                    int lastIndex = LastApplication.RegistrationNumber.IndexOf("-");
                    string lastNumber = LastApplication.RegistrationNumber[0].ToString();
                    for (int i = 0; i < lastIndex - 1; i++)
                    {
                        lastNumber += LastApplication.RegistrationNumber[i].ToString();
                    }
                    int FinalNumber = int.Parse(lastNumber);
                    RegNum = (FinalNumber + 1).ToString() + "-{";
                }
                RegNum = RegNum +
                newApplication.PostDate.Value.Day + 
                "." +
                newApplication.PostDate.Value.Month + 
                "." +
                newApplication.PostDate.Value.Year +
                "}";

                newApplication.RegistrationNumber = RegNum;
                newApplication.IsActive = true;
                Context.Applications.Add(newApplication);

                if (Context.SaveChanges() == 0)
                {
                    return "Post unsuccessfull";
                }

            }
            else
            {
                Console.WriteLine("Application has a null value!");
                return "Application has a null value!";
            }

            Console.WriteLine("Post successful");
            return "Post successful";

        }
        //UPDATE
        public string updateApplication(int id, Application newApplication)
        {
            if (isIdCorrect(id))
            {
                if (newApplication != null)
                {
                    var ApplicationToUpdate = getApplicationById(id);

                    ApplicationToUpdate.Sender = newApplication.Sender;
                    ApplicationToUpdate.Subject = newApplication.Subject;

                    Context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Application has a null value!");
                    return "Application has a null value!";
                }

                Console.WriteLine("Update successful");
                return "Update successful";
            }
            else
            {
                Console.WriteLine("Invalid id!!!");
                return "Invalid id!!!";
            }
        }
        //DELETE
        public string deleteApplication(int id)
        {
            if (isIdCorrect(id))
            {
                Application objectToDelete = getApplicationById(id);

                objectToDelete.IsActive = false;
                
                Context.SaveChanges();

                Console.WriteLine("Delete successful!");
                return "Delete successful!";
            }
            Console.WriteLine("Delete unsuccessful");
            return "Delete unsuccessfull";
        }
    }
}
