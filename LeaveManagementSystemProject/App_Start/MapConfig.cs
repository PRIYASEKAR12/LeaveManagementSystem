using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeaveManagementSystemEntity;

namespace LeaveManagementSystemProject.Models
{
    public class MapConfig
    {
        public static void Mapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeModel,Employee>();
                config.CreateMap<LeaveModel, Leave>().ForMember(dest => dest.LeaveId, act => act.Ignore());
                config.CreateMap<Leave, LeaveModel>().ForMember(dest => dest.EmployeeName, act => act.Ignore());
            });

        }
    }
}