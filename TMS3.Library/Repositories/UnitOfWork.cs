using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Transactions;
using TMS3.Library.Entities;
using TMS3.Library.Interfaces;

namespace TMS3.Library.Repositories
{
    /// <summary>
    /// For items that require more than single entity operations, the GenericUnitOfWork provides a way
    /// to chain DataActions together to perform work on the same context.  A typical interaction would be to
    /// create the GenericUnitOfWork, add IDataActions to it and the call the Save method (which performs the
    /// actions in the order they were added all on the same context, and then call SaveChanges on the context
    /// (making the GenericRepositories pass-through the context).
    /// </summary>
    public class UnitOfWork
    {
        private ILogger<TMSContext> _logger;
        private TMSContext _context;
        private Repository<Person> _personRepository;
        private Repository<Task> _taskRepository;

        public UnitOfWork(TMSContext cont,ILogger<TMSContext> logger)
        {
            _logger = logger;
            _context = cont;
        }

        public IRepository<Person> PersonRepository
        {
            get
            {
                return _personRepository = _personRepository ?? new Repository<Person>(_context,_logger);
            }
        }
        public IRepository<Task> TaskRepository
        {
            get
            {
                return _taskRepository = _taskRepository ?? new Repository<Task>(_context,_logger);
            }
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
