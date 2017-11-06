using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS3.Library.Entities
{
   public  class Seed
    {

        private readonly TMSContext _ctx;

        public Seed(TMSContext ctx)
        {
            _ctx = ctx;
        }

        public void Add()
        {
            _ctx.Database.EnsureCreated();

            if(!_ctx.Persons.Any())
            {
                var person = new Person()
                {
                    FirstName = "Kume",
                    LastName = "LN",
                    EmailAddress = "kmw@email.com",
                    PhoneNumber = "1234567890",
                    JrnCreatedBy = "kmw",
                    JrnCreatedDate = DateTime.Now,
                    JrnModifiedBy = "TBD",
                    JrnModifiedDate = DateTime.Now


                };
                _ctx.Add(person);

                var task = new List<Task>()
                {
                   new Task {
                    TaskNumber = 1000,
                    TaskName = "Project Management",
                    DescText = "Task for management",
                    CommentText = "",
                    TaskStatusRefrenceTypeID = 302,
                    ElementCodeID = 36,
                    IsOverhead = false,
                    IsAllocable = true,
                    IsUpdateREquired = true,
                    JrnCreatedBy = "me",
                    JrnCreatedDate = DateTime.Now,
                    JrnModifiedBy="TBD",
                    JrnModifiedDate=DateTime.Now
                    },

                   new Task {
                    TaskNumber = 1001,
                    TaskName = "NonBillable",
                    DescText = "Non Billable Projects",
                    CommentText = "",
                    TaskStatusRefrenceTypeID = 302,
                    ElementCodeID = 36,
                    IsOverhead = false,
                    IsAllocable = true,
                    IsUpdateREquired = true,
                    JrnCreatedBy = "me",
                    JrnCreatedDate = DateTime.Now,
                    JrnModifiedBy="TBD",
                    JrnModifiedDate=DateTime.Now
                    },
                };
                _ctx.AddRange(task);

                var taskCont = new List<TaskContact>()
                {
                    new TaskContact(){
                    ContactTypeID = 1,
                    Person = person,
                    Task = task.First(),
                    JrnCreatedBy = "me",
                    JrnCreatedDate = DateTime.Now,
                    JrnModifiedBy = "TBD",
                    JrnModifiedDate = DateTime.Now }
                    ,
                    new TaskContact(){
                    ContactTypeID = 1,
                    Person = person,
                    Task = task.First(w=>w.TaskNumber==1001),
                    JrnCreatedBy = "me",
                    JrnCreatedDate = DateTime.Now,
                    JrnModifiedBy = "TBD",
                    JrnModifiedDate = DateTime.Now }
                };
                _ctx.AddRange(taskCont);

                var taskDate = new List<TaskDate>()
                {
                    new TaskDate
                    {
                        Task=task.First(),
                        Person=person,
                        ActionDate=DateTime.Now,
                        TaskDateReferenceTypeID=1,
                        JrnCreatedBy = "me",
                        JrnCreatedDate = DateTime.Now,
                        JrnModifiedBy = "TBD",
                        JrnModifiedDate = DateTime.Now
                    },
                    new TaskDate
                    {
                        Task=task.First(r=>r.TaskNumber==1001),
                        Person=person,
                        ActionDate=DateTime.Now,
                        TaskDateReferenceTypeID=1,
                        JrnCreatedBy = "me",
                        JrnCreatedDate = DateTime.Now,
                        JrnModifiedBy = "TBD",
                        JrnModifiedDate = DateTime.Now
                    }
                };
                _ctx.AddRange(taskDate);

                var taskCost = new List<TaskCost>()
                {
                    new TaskCost
                    {
                        Task=task.First(),
                        PONumber="123",
                        VendorTypeReferenceTypeID=2,
                        Amount=201,
                        CostTitle="Misc",
                        ExpenseTypeReferenceTypeID=1,
                        IsEstimate=true,
                        ParentTaskCostID=1,
                        DescText="",
                        JrnCreatedBy = "me",
                        JrnCreatedDate = DateTime.Now,
                        JrnModifiedBy = "TBD",
                        JrnModifiedDate = DateTime.Now

                    }
                    ,  new TaskCost
                    {
                        Task=task.First(r=>r.TaskNumber==1001),
                        PONumber="123",
                        VendorTypeReferenceTypeID=2,
                        Amount=201,
                        CostTitle="Misc",
                        ExpenseTypeReferenceTypeID=1,
                        IsEstimate=true,
                        ParentTaskCostID=1,
                        DescText="",
                        JrnCreatedBy = "me",
                        JrnCreatedDate = DateTime.Now,
                        JrnModifiedBy = "TBD",
                        JrnModifiedDate = DateTime.Now

                    }
                };
                _ctx.AddRange(taskCost);

                _ctx.SaveChanges();
            }
        }
    }
}
