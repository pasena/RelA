using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelA.Domain.Entities;

namespace RelA.WebUI.Models.Create
{
    public class TaskAddViewModel
    {
        public Task Task { get; set; }

        public IEnumerable<Project> Projetos { get; set; }
    }
}