using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;

namespace RelA.Domain.Concrete
{
    public class ProjectRepository : IProjectRepository
    {
        private RelAContext context = null;

        public ProjectRepository()
        {
            context = new RelAContext();
        }

        public IQueryable<Entities.Project> GetAll()
        {
            return context.Projects;
        }

        public void Save(Entities.Project entity)
        {
            if (entity.ProjectID == 0)
            {
                context.Projects.Add(entity);
            }
            else
            {
                Project editProject = context.Projects.FirstOrDefault(w => w.ProjectID == entity.ProjectID);

                if (editProject != null)
                {
                    context.Entry(editProject).CurrentValues.SetValues(entity);
                }
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Project deleteProject = context.Projects.FirstOrDefault(w => w.ProjectID == id);

            if (deleteProject != null)
            {
                context.Projects.Remove(deleteProject);
            }

            context.SaveChanges();
        }
    }
}
