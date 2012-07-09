using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelA.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelA.WebUI.Models
{
    public class TaskDetailsViewModel
    {
        public Task Task { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<TaskStatus> Status { get; set; }

        [HiddenInput(DisplayValue=false)]
        public int SelectedTaskStatusID { get; set; }
    }
}