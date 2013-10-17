using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace Services
{
    public class OrganizationSvcImpl : IOrganizationService
    {
        public void AddOrganization()
        {
            throw new NotImplementedException();
        }

        public void AddOrganization(Organization organization)
        {
            var organizationRepository = RepositoryFactory.Create("Organization");

            //add org to database
            organizationRepository.Insert(organization);
        }

        public Organization GetOrganization(int id)
        {
            Organization organization = new Organization();
            organization = null;
            try
            {
                var organizationRepository = new DataRepository<Organization>();


                //return an organization
                List<Organization> myOrgs =
                    organizationRepository.GetBySpecificKey("OrganizationId", id).ToList<Organization>();

                //should only be one, but just get the first record
                organization = myOrgs[0];

                if (organization == null)
                {
                    throw new OrganizationNotFoundException("Organization not found!");
                }
            }
            catch (OrganizationNotFoundException onfe)
            {
                System.Console.WriteLine("Caught OrganizationNotFoundException" + onfe);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception" + e);
            }
            return organization;
        }

        public void UpdateOrganization(Organization organization)
        {
            //create repository of the correct type
            var organizationRepository = RepositoryFactory.Create("Organization");

            //update the organization
            organizationRepository.Update(organization);
        }

        public void DeleteOrganization(Organization organization)
        {
            //create repository of the correct type
            var organizationRepository = RepositoryFactory.Create("Organization");

            //delete the organization
            organizationRepository.Delete(organization);
        }

        List<Organization> IOrganizationService.GetAllOrganizations()
        {
            var orgRepo = new DataRepository<Organization>();
            List<Organization> orgList = orgRepo.GetAll().ToList<Organization>();

            return orgList;
        }
    }
}