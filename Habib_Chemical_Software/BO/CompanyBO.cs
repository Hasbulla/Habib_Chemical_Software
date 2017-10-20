using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class CompanyBO
    {
        Shared<Company> rep = new Shared<Company>();
        Habib_ChemicalsEntities hef = new Habib_ChemicalsEntities();

        public IEnumerable<Company> GetAll()
        {
            return rep.GetAll(c => c.deleted == false);
        }
        public Company GetById(int id)
        {
            return rep.GetById(id);
        }
        public Company Add(Company entity, string dynamicName1, string dynamicName2, string dynamicName3, string dynamicName4, string dynamicContact1, string dynamicContact2, string dynamicContact3, string dynamicContact4)
        {
            var company = rep.Add(entity);

            if (dynamicName1 != null && dynamicContact1 != null)
                AddCompanyContact(company.id, dynamicName1, dynamicContact1);
            if (dynamicName2 != null && dynamicContact2 != null)
                AddCompanyContact(company.id, dynamicName2, dynamicContact2);
            if (dynamicName3 != null && dynamicContact3 != null)
                AddCompanyContact(company.id, dynamicName3, dynamicContact3);
            if (dynamicName4 != null && dynamicContact4 != null)
                AddCompanyContact(company.id, dynamicName4, dynamicContact4);

            return company;

        }
        public void AddCompanyContact(int id, string dynamicName, string dynamicContact)
        {
            Company_Contact_Persons ccp = new Company_Contact_Persons
            {
                company_id = id,
                name = dynamicName,
                contact = dynamicContact
            };
            hef.Company_Contact_Persons.Add(ccp);
            try
            {
                hef.SaveChanges();
            }
            catch (Exception ex)
            {
                var val = ex;
            }
        }
        public void Update(Company company, string dynamicName1, string dynamicName2, string dynamicName3, string dynamicName4, string dynamicContact1, string dynamicContact2, string dynamicContact3, string dynamicContact4)
        {
            rep.Update(company);
            DeleteCompanyContact(company.id);

            if (dynamicName1 != null && dynamicContact1 != null)
                AddCompanyContact(company.id, dynamicName1, dynamicContact1);
            if (dynamicName2 != null && dynamicContact2 != null)
                AddCompanyContact(company.id, dynamicName2, dynamicContact2);
            if (dynamicName3 != null && dynamicContact3 != null)
                AddCompanyContact(company.id, dynamicName3, dynamicContact3);
            if (dynamicName4 != null && dynamicContact4 != null)
                AddCompanyContact(company.id, dynamicName4, dynamicContact4);
        }
        public void DeleteCompanyContact(int id)
        {
            //var item = hef.Company_Contact_Persons.First(c => c.company_id == id);
            //hef.Entry(item).State = EntityState.Deleted;
            //hef.SaveChanges();

            hef.Company_Contact_Persons.RemoveRange(hef.Company_Contact_Persons.Where(c => c.company_id == id));
        }
        public void Delete(int id)
        {
            rep.Delete(id);
        }
        public void Dispose()
        {
            rep.Dispose();
        }
    }
}