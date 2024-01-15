using AutoMapper;
using LarTechAPi.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarTechApi.XUnitTests
{
    public class BaseTest
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(op =>
            {
                op.AddProfile<DomainToDTOMappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}
