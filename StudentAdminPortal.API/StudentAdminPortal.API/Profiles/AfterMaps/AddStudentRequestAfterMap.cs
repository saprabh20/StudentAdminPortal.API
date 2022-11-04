using AutoMapper;
using StudentAdminPortal.API.Domain_Models;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, Data_Models.Student>
    {
        public void Process(AddStudentRequest source, Data_Models.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Data_Models.Address()
            {
                Id = Guid.NewGuid(),
                PhysicalAddress=source.PhysicalAddress, 
                PostalAddress=source.PostalAddress
            };
        }
    }
}
