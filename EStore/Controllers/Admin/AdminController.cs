using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminController
    {
    }
}
