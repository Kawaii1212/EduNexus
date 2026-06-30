using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EduNexus.Models;

namespace EduNexus.DAOs;

public class BaseDAO<T> where T : class
{
    private static BaseDAO<T>? instance = null;
    private static readonly object instanceLock = new object();

    protected BaseDAO() { }

    public static BaseDAO<T> Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new BaseDAO<T>();
                }
                return instance;
            }
        }
    }

    protected EduNexusNew02Context GetContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<EduNexusNew02Context>();
        optionsBuilder.UseSqlServer(AppConfiguration.ConnectionString);
        return new EduNexusNew02Context(optionsBuilder.Options);
    }

    public virtual IEnumerable<T> GetAll()
    {
        using var context = GetContext();
        return context.Set<T>().ToList();
    }

    public virtual T? GetById(object id)
    {
        using var context = GetContext();
        return context.Set<T>().Find(id);
    }

    public virtual void Add(T entity)
    {
        using var context = GetContext();
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        using var context = GetContext();
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }

    public virtual void Delete(T entity)
    {
        using var context = GetContext();
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }
}
